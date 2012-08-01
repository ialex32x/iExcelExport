using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iExcelExport.DB
{
	public class ExcelXMLLayout
	{
		#region 内嵌类型
		public enum KeyType
		{
			Integer,
			String,
			Unknown,
		}
		public class KeyPair
		{
			public string name;
			public KeyType type;
			public int index;
			
			public string text { get { return string.Format("{0}:{1}", name, ExcelXMLLayout.Type2Text(type)); } }
		}
		#endregion

		private string m_path;
		private string m_sheet;
		private string m_name;
		private string m_summary;
		private string m_primary;
		private string m_primary_comment;
		private List<KeyPair> m_allkey;
		private ExcelSolution m_solution;
		private bool m_typed;

		public ExcelXMLLayout(ExcelSolution solution)
		{
			m_primary = "id";
			m_primary_comment = "";
			m_typed = true;
			m_path = "样例.xml";
			m_allkey = new List<KeyPair>(10);
			m_solution = solution;
			m_name = "sample";
			m_sheet = "Sheet1";
		}

		public KeyPair Add(string name, KeyType type)
		{
			KeyPair kp = new KeyPair();
			kp.name = name;
			kp.type = type;
			kp.index = m_allkey.Count;
			m_allkey.Add(kp);
			return kp;
		}


		public bool typed { get { return m_typed; } set { m_typed = value; } }
		public ExcelSolution solution { get { return m_solution; } set { m_solution = value; } }
		public string primary { get { return m_primary; } set { m_primary = value; } }
		public string primaryComment { get { return m_primary_comment; } set { m_primary_comment = value; } }
		public string summary { get { return m_summary; } set { m_summary = value; } }
		public string name { get { return m_name; } set { m_name = value; } }
		public string path { get { return m_path; } set { m_path = value; } }
		public string sheet { get { return m_sheet; } set { m_sheet = value; } }
		public int count { get { return m_allkey.Count; } }
		public KeyPair this[int index] { get { return m_allkey[index]; } }
		public string text { get { return m_sheet + (m_summary == "" ? "" : ":") + m_summary; } }

		public IEnumerable<KeyPair> EachKeyPair()
		{
			return m_allkey;
		}

		public static string Type2Text(KeyType t)
		{
			switch (t)
			{
				case KeyType.Integer:
					return "整数";
				case KeyType.String:
					return "文本";
				default:
					return "未知类型";
			}
		}
		public static int Type2Int(KeyType t)
		{
			switch (t)
			{
				case KeyType.Integer:
					return 1;
				case KeyType.String:
					return 3;
				default:
					return 3;
			}
		}

		public void Clear()
		{
			m_allkey.Clear();
		}

		public void RemoveSelf()
		{
			solution.RemoveLayout(this);
		}

		public void Remove(KeyPair kp)
		{
			m_allkey.Remove(kp);
		}
	}
}
