using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iExcelExport.DB
{
	public class ExcelSolution
	{
		private string m_name;
		private string m_path;
		private List<ExcelXMLLayout> m_layouts;
		private ExcelManager m_mgr;

		public ExcelSolution(ExcelManager mgr)
		{
			m_name = "新Excel文件";
			m_layouts = new List<ExcelXMLLayout>(10);
			m_mgr = mgr;
		}

		public string text { get { return m_name; } }
		public string path { get { return m_path; } set { m_path = value; } }
		public string name
		{
			get { return m_name; }
			set { 
				//TODO: 在mgr中检查是否重复名字存在

				m_name = value; 
			}
		}

		public void AddLayout(ExcelXMLLayout layout)
		{
			m_layouts.Add(layout);
		}

		public IEnumerable<ExcelXMLLayout> EachLayout()
		{
			return m_layouts;
		}

		public void RemoveLayout(ExcelXMLLayout layout)
		{
			m_layouts.Remove(layout);
		}
	}
}
