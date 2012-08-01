using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iExcelExport.DB
{
	public class ExcelManager
	{
		private List<ExcelSolution> m_solutions;

		public ExcelManager()
		{
			m_solutions = new List<ExcelSolution>(10);
		}

		public void AddSolution(ExcelSolution solu)
		{
			m_solutions.Add(solu);
		}

		public bool Save(string file = "config.xml")
		{
			System.Xml.XmlWriter w = System.Xml.XmlWriter.Create(file);
			w.WriteStartDocument();

			w.WriteStartElement("root");
			foreach (ExcelSolution solu in m_solutions)
			{
				w.WriteStartElement("excel");
				w.WriteAttributeString("name", solu.name);
				w.WriteAttributeString("path", solu.path);
				foreach (ExcelXMLLayout layout in solu.EachLayout())
				{
					w.WriteStartElement("layout");
					w.WriteAttributeString("path", layout.path);
					w.WriteAttributeString("sheet", layout.sheet);
					w.WriteAttributeString("name", layout.name);
					w.WriteAttributeString("summary", layout.summary);
					w.WriteAttributeString("typed", layout.typed.ToString());
					w.WriteAttributeString("primary", layout.primary);
					w.WriteAttributeString("primary-comment", layout.primaryComment);

					foreach (ExcelXMLLayout.KeyPair key in layout.EachKeyPair())
					{
						w.WriteStartElement("column");
						w.WriteAttributeString("type", key.type.ToString());
						w.WriteValue(key.name);
						w.WriteEndElement();
					}
					w.WriteEndElement();
				}
				w.WriteEndElement();
			}
			w.WriteEndElement();

			w.WriteEndDocument();
			w.Close();
			return true;
		}

		public bool Load(string file = "config.xml")
		{
			try
			{
				System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

				doc.Load(file);
				System.Xml.XmlNode root = doc.SelectSingleNode("root");
				m_solutions.Clear();
				foreach (System.Xml.XmlNode xls in root.SelectNodes("excel"))
				{
					ExcelSolution solu = new ExcelSolution(this);
					solu.name = xls.Attributes["name"].Value;
					solu.path = xls.Attributes["path"].Value;

					foreach (System.Xml.XmlNode layoutNode in xls.SelectNodes("layout"))
					{
						ExcelXMLLayout layout = new ExcelXMLLayout(solu);
						layout.path = layoutNode.Attributes["path"].Value;
						layout.sheet = layoutNode.Attributes["sheet"].Value;
						layout.name = layoutNode.Attributes["name"].Value;
						layout.summary = layoutNode.Attributes["summary"].Value;
						layout.typed = bool.Parse(layoutNode.Attributes["typed"].Value);
						try { layout.primary = layoutNode.Attributes["primary"].Value; }
						catch (Exception) { }
						try { layout.primaryComment = layoutNode.Attributes["primary-comment"].Value; }
						catch (Exception) { }

						foreach (System.Xml.XmlNode column in layoutNode.SelectNodes("column"))
						{
							layout.Add(
								column.InnerText,
								(ExcelXMLLayout.KeyType)Enum.Parse(typeof(ExcelXMLLayout.KeyType), column.Attributes["type"].Value)
							);
						}
						solu.AddLayout(layout);
					}

					AddSolution(solu);
				}
				return true;
			}
			catch (Exception err)
			{
				System.Diagnostics.Debug.WriteLine(err.Message);
			}
			return false;
		}

		public IEnumerable<ExcelSolution> EachSolution()
		{
			return m_solutions;
		}

		public void RemoveSolution(ExcelSolution solu)
		{
			m_solutions.Remove(solu);
		}
	}
}
