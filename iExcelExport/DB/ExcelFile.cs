using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iExcelExport.DB
{
	public class ExcelFile
	{
		public static string MakeConnectionString(string file)
		{
			return string.Format(
				"Provider=Microsoft.ACE.OleDb.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=Yes'"
				, file);
		}

		public static string MakeSelectString(ExcelXMLLayout layout)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("SELECT ");

			int index = 1;
			foreach (ExcelXMLLayout.KeyPair k in layout.EachKeyPair())
			{
				sb.Append("[");
				sb.Append(k.name);
				sb.Append("]");
				if (index != layout.count)
				{
					sb.Append(",");
				}
				index++;
			}
			sb.Append(" FROM [");
			sb.Append(layout.sheet);
			sb.Append("$]");
			return sb.ToString();
		}

		public static bool IsHeadRow(System.Data.OleDb.OleDbDataReader r, ExcelXMLLayout layout)
		{
			if (layout[0].name.ToLower() == layout.primary)
			{
				string val = r[0].ToString();

				return (val == "" ||
					(val.Length >= 2 && val.Substring(0, 2) == "__") ||
					(val.Length >= 2 && val.Substring(0, 2) == "表头") ||
					(val.Length >= 2 && val.Substring(0, 2) == "编号")
					);
			}
			for (int i = 0; i < layout.count; ++i)
			{
				if (layout[i].name.ToLower()==layout.primary)
				{
					return r[i].ToString() == layout.primaryComment;
				}
			}
			if (layout[0].name.ToLower() == "id")
			{
				string val = r[0].ToString();

				return (val == "" ||
					(val.Length >= 2 && val.Substring(0, 2) == "__") ||
					(val.Length >= 2 && val.Substring(0, 2) == "表头") ||
					(val.Length >= 2 && val.Substring(0, 2) == "编号")
					);
			}
			return false;
		}

		public static string lastError = "";
		public static bool DoExport(ExcelXMLLayout layout)
		{
			try
			{
				System.Data.OleDb.OleDbConnection conn =
					new System.Data.OleDb.OleDbConnection(DB.ExcelFile.MakeConnectionString(layout.solution.path));

				StringBuilder sb = new StringBuilder(1024 * 1024);
				try
				{
					conn.Open();
					System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(
						DB.ExcelFile.MakeSelectString(layout), conn);

					try
					{
						System.Data.OleDb.OleDbDataReader r = cmd.ExecuteReader();
						sb.Append("<?xml version='1.0' encoding='utf-8'?>");
						sb.Append("<dataroot>");
						while (r.Read())
						{
							if (IsHeadRow(r, layout))
							{
								continue;
							}
							sb.AppendFormat("<{0}>", layout.name);
							for (int i = 0; i < r.FieldCount; ++i)
							{
								if (layout.typed)
								{
									sb.AppendFormat("<{0} type='{1}'>{2}</{0}>",
										layout[i].name, ExcelXMLLayout.Type2Int(layout[i].type), r[i].ToString());
								}
								else
								{
									sb.AppendFormat("<{0}>{1}</{0}>", layout[i].name, r[i].ToString());
								}
							}
							sb.AppendFormat("</{0}>", layout.name);
						}
						sb.Append("</dataroot>");
						r.Dispose();
					}
					catch (Exception rErr)
					{
						lastError = string.Format("表格查询命令\r\n{0}", rErr.ToString());
						cmd.Dispose();
						conn.Close();
						conn.Dispose();
						return false;
					}
					cmd.Dispose();
					conn.Close();
					conn.Dispose();
				}
				catch (Exception connOpenErr)
				{
					lastError = string.Format("表格打开失败\r\n{0}", connOpenErr.ToString());
					conn.Dispose();
					return false;
				}
				//System.Diagnostics.Debug.WriteLine(sb.ToString());

				try
				{
					System.IO.TextWriter w = System.IO.File.CreateText(layout.path);
					w.Write(sb.ToString());
					w.Close();
				}
				catch (Exception wErr)
				{
					lastError = string.Format("目标XML文件无法写入\r\n{0}", wErr.ToString());
					return false;
				}

				return true;
			}
			catch (Exception outErr)
			{
				lastError = string.Format("Excel 无法打开\r\n{0}", outErr.ToString());
				System.Diagnostics.Debug.WriteLine(outErr.ToString());
			}
			return false;
		}

		public static bool AnalyzeExcel(ExcelXMLLayout layout)
		{
			System.Data.OleDb.OleDbConnection conn = null;
			try
			{
				conn = new System.Data.OleDb.OleDbConnection(MakeConnectionString(layout.solution.path));

				conn.Open();
				System.Data.DataTable table = conn.GetOleDbSchemaTable(
					System.Data.OleDb.OleDbSchemaGuid.Columns,
					new object[] { null, null, layout.sheet + "$", null });

				layout.Clear();
				System.Diagnostics.Debug.WriteLine("Start Analyze [" + table.Rows.Count + "]");

				foreach (System.Data.DataRow row in table.Rows)
				{
					string name = row["Column_Name"].ToString();

					System.Diagnostics.Debug.WriteLine(name);

					// 测试数据类型
					ExcelXMLLayout.KeyType testType = ExcelXMLLayout.KeyType.Unknown;
					{
						System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(
							string.Format("select [{0}] from [{1}$]", name, layout.sheet), conn
							);
						System.Data.OleDb.OleDbDataReader r = cmd.ExecuteReader();
						while (r.Read())
						{
							System.Diagnostics.Debug.WriteLine(r[0].GetType());
							if (r[0].GetType() == typeof(System.Double))
							{
								testType = ExcelXMLLayout.KeyType.Integer;
								break;
							}
							if (testType == ExcelXMLLayout.KeyType.String)
							{
								break;
							}
							testType = ExcelXMLLayout.KeyType.String;
						}
						r.Close();
						cmd.Dispose();
					}

					layout.Add(name, testType);
				}
				table.Dispose();
				conn.Close();

				return true;
			}
			catch (Exception outErr)
			{
				lastError = string.Format("无法分析，Excel 无法打开\r\n{0}", outErr.Message);
			}
			return false;
		}
	}
}
