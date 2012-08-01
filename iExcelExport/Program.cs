using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iExcelExport
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			//DB.ExcelFile.AnalyzeExcel("test.xlsx", "Sheet1");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
