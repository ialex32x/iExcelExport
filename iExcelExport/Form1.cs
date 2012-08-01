using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iExcelExport
{
	public partial class Form1 : Form
	{
		private DB.ExcelManager mgr;
		private DB.ExcelSolution m_currentSolution = null;
		private DB.ExcelXMLLayout m_currentLayout = null;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Util_BuildConfigList();

			if (cmbAllConfig.Items.Count > 0)
			{
				int index = cmbAllConfig.Items.IndexOf(Environment.UserName + ".xml");
				if (index != -1)
				{
					cmbAllConfig.SelectedIndex = index;
				}
				else
				{
					cmbAllConfig.SelectedIndex = 0;
					cmbAllConfig.Items.Add(Environment.UserName + ".xml");
				}
			}
		}

		private void cmbAllConfig_SelectedIndexChanged(object sender, EventArgs e)
		{
			DB.ExcelManager mgr_t = new DB.ExcelManager();
			if (!mgr_t.Load("user\\" + cmbAllConfig.Text))
			{
				MessageBox.Show(this, "配置加载失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}
			mgr = mgr_t;
			Util_BuildExcelTV();
			tvExcel.ExpandAll();

			Util_ShowLayout();
			Util_ShowSolution();
		}

		public DB.ExcelSolution CurrentSolution
		{
			get { return m_currentSolution; }
			set
			{
				if (m_currentSolution != value)
				{
					m_currentSolution = value;
				}
			}
		}

		public DB.ExcelXMLLayout CurrentLayout
		{
			get { return m_currentLayout; }
			set
			{
				if (m_currentLayout != value)
				{
					m_currentLayout = value;
				}
			}
		}

		private void Util_BuildConfigList()
		{
			string[] files = System.IO.Directory.GetFiles("user", "*.xml");
			foreach (string file in files)
			{
				cmbAllConfig.Items.Add(new System.IO.FileInfo(file).Name);
			}
		}

		private void Util_BuildExcelTV()
		{
			tvExcel.Nodes.Clear();
			TreeNode root = tvExcel.Nodes.Add("所有表格");
			root.SelectedImageKey = root.ImageKey = "ROOT";

			foreach (DB.ExcelSolution solu in mgr.EachSolution())
			{
				Util_AddExcelSolution(root, solu);
			}
		}

		private void Util_AddExcelSolution(TreeNode root, DB.ExcelSolution solu)
		{
			TreeNode soluNode = new TreeNode(solu.text);
			soluNode.Name = solu.name;
			soluNode.Tag = solu;
			soluNode.SelectedImageKey = soluNode.ImageKey = "EXCEL";

			foreach (DB.ExcelXMLLayout layout in solu.EachLayout())
			{
				Util_AddLayout(soluNode, layout);
			}
			root.Nodes.Add(soluNode);
		}

		private void Util_AddLayout(TreeNode soluNode, DB.ExcelXMLLayout layout)
		{
			TreeNode layoutNode = new TreeNode(layout.text);
			layoutNode.Name = layout.path;
			layoutNode.Tag = layout;
			layoutNode.SelectedImageKey = layoutNode.ImageKey = "LAYOUT";

			foreach (DB.ExcelXMLLayout.KeyPair kp in layout.EachKeyPair())
			{
				Util_AddKeyPair(layoutNode, kp);
			}
			soluNode.Nodes.Add(layoutNode);
		}

		private void Util_AddKeyPair(TreeNode layoutNode, DB.ExcelXMLLayout.KeyPair kp)
		{
			TreeNode kpNode = new TreeNode(kp.text);
			kpNode.Name = kp.name;
			kpNode.Tag = kp;
			kpNode.SelectedImageKey = kpNode.ImageKey = "KEYPAIR";

			layoutNode.Nodes.Add(kpNode);
		}

		private void tvExcel_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				tvExcel.SelectedNode = e.Node;
				if (e.Node.Level == 0)
				{
					ctxAllExcel.Show(MousePosition);
				}
				else if (tvExcel.SelectedNode.Tag is DB.ExcelXMLLayout)
				{
					ctxExport.Show(MousePosition);
				}
				else if (tvExcel.SelectedNode.Tag is DB.ExcelXMLLayout.KeyPair)
				{
					ctxKeyPair.Show(MousePosition);
				}
				else if (tvExcel.SelectedNode.Tag is DB.ExcelSolution)
				{
					ctxBatchExport.Show(MousePosition);
				}
			}
		}

		private void Util_ShowSolution()
		{
			if (CurrentSolution == null)
			{
				txtExcelName.Enabled = false;
				txtExcelPath.Enabled = false;
			}
			else
			{
				txtExcelName.Text = CurrentSolution.name;
				txtExcelPath.Text = CurrentSolution.path;
				txtExcelName.Enabled = true;
				txtExcelPath.Enabled = true;
			}
		}

		private void Util_ShowLayout()
		{
			if (CurrentLayout == null)
			{
				txtSummary.Enabled = false;
				txtItemName.Enabled = false;
				txtExportPath.Enabled = false;
				txtSheetName.Enabled = false;
				chkTypedLayout.Enabled = false;
			}
			else
			{
				txtSummary.Text = CurrentLayout.summary;
				txtItemName.Text = CurrentLayout.name;
				txtExportPath.Text = CurrentLayout.path;
				txtSheetName.Text = CurrentLayout.sheet;
				chkTypedLayout.Checked = CurrentLayout.typed;
				txtSummary.Enabled = true;
				txtItemName.Enabled = true;
				txtExportPath.Enabled = true;
				txtSheetName.Enabled = true;
				chkTypedLayout.Enabled = true;
			}
		}

		private bool Util_DoExport(DB.ExcelXMLLayout layout)
		{
			return DB.ExcelFile.DoExport(layout);
		}

		private void 导出XMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (tvExcel.SelectedNode.Tag is DB.ExcelXMLLayout)
			{
				if (Util_DoExport(tvExcel.SelectedNode.Tag as DB.ExcelXMLLayout))
				{
					MessageBox.Show(this, "成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(this, DB.ExcelFile.lastError, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void 猜测格式ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (tvExcel.SelectedNode.Tag is DB.ExcelXMLLayout)
			{
				DB.ExcelXMLLayout layout = tvExcel.SelectedNode.Tag as DB.ExcelXMLLayout;

				DB.ExcelFile.AnalyzeExcel(layout);
				tvExcel.SelectedNode.Nodes.Clear();
				foreach (DB.ExcelXMLLayout.KeyPair kp in layout.EachKeyPair())
				{
					Util_AddKeyPair(tvExcel.SelectedNode, kp);
				}
			}
		}

		private void 整数ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DB.ExcelXMLLayout.KeyPair kp = tvExcel.SelectedNode.Tag as DB.ExcelXMLLayout.KeyPair;
			kp.type = DB.ExcelXMLLayout.KeyType.Integer;
			tvExcel.SelectedNode.Text = kp.text;
		}

		private void 字符串ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DB.ExcelXMLLayout.KeyPair kp = tvExcel.SelectedNode.Tag as DB.ExcelXMLLayout.KeyPair;
			kp.type = DB.ExcelXMLLayout.KeyType.String;
			tvExcel.SelectedNode.Text = kp.text;
		}

		private void 全部导出XToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (tvExcel.SelectedNode.Tag is DB.ExcelSolution)
			{
				List<string> failed = new List<string>(5);
				DB.ExcelSolution solu = tvExcel.SelectedNode.Tag as DB.ExcelSolution;

				foreach (DB.ExcelXMLLayout layout in solu.EachLayout())
				{
					if (!Util_DoExport(layout))
					{
						failed.Add(layout.text);
					}

				}
				if (failed.Count == 0)
				{
					MessageBox.Show(this, "全部导出成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					StringBuilder sb = new StringBuilder();

					foreach (string msg in failed)
					{
						sb.AppendLine(msg);
					}
					MessageBox.Show(this, "以下项目导出失败：\r\n" + sb.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private void 导出所有ExcelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<string> failed = new List<string>(15);

			foreach (DB.ExcelSolution solu in mgr.EachSolution())
			{
				foreach (DB.ExcelXMLLayout layout in solu.EachLayout())
				{
					if (!Util_DoExport(layout))
					{
						failed.Add(layout.text);
					}
				}
			}
			if (failed.Count == 0)
			{
				MessageBox.Show(this, "全部导出成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				StringBuilder sb = new StringBuilder();

				foreach (string msg in failed)
				{
					sb.AppendLine(msg);
				}
				MessageBox.Show(this, "以下项目导出失败：\r\n" + sb.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}

		private void 添加LayoutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DB.ExcelSolution solu = tvExcel.SelectedNode.Tag as DB.ExcelSolution;

			DB.ExcelXMLLayout layout = new DB.ExcelXMLLayout(solu);
			solu.AddLayout(layout);
			Util_AddLayout(tvExcel.SelectedNode, layout);
		}

		private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CurrentLayout.RemoveSelf();
			tvExcel.SelectedNode.Remove();
		}

		private void 添加新数据ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DB.ExcelXMLLayout.KeyPair kp = CurrentLayout.Add("NewColumn", DB.ExcelXMLLayout.KeyType.Unknown);
			Util_AddKeyPair(tvExcel.SelectedNode, kp);
		}

		private void 删除此数据ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DB.ExcelXMLLayout.KeyPair kp = tvExcel.SelectedNode.Tag as DB.ExcelXMLLayout.KeyPair;
			DB.ExcelXMLLayout layout = tvExcel.SelectedNode.Parent.Tag as DB.ExcelXMLLayout;
			layout.Remove(kp);
			tvExcel.SelectedNode.Remove();
		}

		private void 添加ExcelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DB.ExcelSolution solu = new DB.ExcelSolution(mgr);

			mgr.AddSolution(solu);
			Util_AddExcelSolution(tvExcel.SelectedNode, solu);
		}

		private void 删除ExcelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			mgr.RemoveSolution(CurrentSolution);
			tvExcel.SelectedNode.Remove();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (mgr.Save("user\\" + cmbAllConfig.Text))
			{
				MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(this, "无法保存", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void tvExcel_AfterSelect(object sender, TreeViewEventArgs e)
		{
			txtColumnName.Enabled = false;

			if (e.Node.Tag is DB.ExcelXMLLayout)
			{
				CurrentLayout = e.Node.Tag as DB.ExcelXMLLayout;
				CurrentSolution = CurrentLayout.solution;
			}
			else if (e.Node.Tag is DB.ExcelSolution)
			{
				CurrentLayout = null;
				CurrentSolution = e.Node.Tag as DB.ExcelSolution;
			}
			else
			{
				CurrentLayout = null;
				CurrentSolution = null;

				if (e.Node.Tag is DB.ExcelXMLLayout.KeyPair)
				{
					txtColumnName.Text = (e.Node.Tag as DB.ExcelXMLLayout.KeyPair).name;
					txtColumnName.Enabled = true;
				}
			}
			Util_ShowLayout();
			Util_ShowSolution();
		}

		private void txtExcelName_TextChanged(object sender, EventArgs e)
		{
			if (!txtExcelName.Enabled) return;
			CurrentSolution.name = txtExcelName.Text;
			//TODO:
			if (tvExcel.SelectedNode.Tag is DB.ExcelSolution)
			{
				tvExcel.SelectedNode.Text = CurrentSolution.text;
			}
			else if (tvExcel.SelectedNode.Tag is DB.ExcelXMLLayout)
			{
				tvExcel.SelectedNode.Parent.Text = CurrentSolution.text;
			}
		}

		private void txtExcelPath_TextChanged(object sender, EventArgs e)
		{
			if (!txtExcelPath.Enabled) return;
			CurrentSolution.path = txtExcelPath.Text;
			//TODO:
			if (tvExcel.SelectedNode.Tag is DB.ExcelSolution)
			{
				tvExcel.SelectedNode.Text = CurrentSolution.text;
			}
			else if (tvExcel.SelectedNode.Tag is DB.ExcelXMLLayout)
			{
				tvExcel.SelectedNode.Parent.Text = CurrentSolution.text;
			}
		}

		private void txtItemName_TextChanged(object sender, EventArgs e)
		{
			if (!txtItemName.Enabled) return;
			CurrentLayout.name = txtItemName.Text;
			tvExcel.SelectedNode.Text = CurrentLayout.text;
		}

		private void txtSummary_TextChanged(object sender, EventArgs e)
		{
			if (!txtSummary.Enabled) return;
			CurrentLayout.summary = txtSummary.Text;
			tvExcel.SelectedNode.Text = CurrentLayout.text;
		}

		private void txtExportPath_TextChanged(object sender, EventArgs e)
		{
			if (!txtExportPath.Enabled) return;
			CurrentLayout.path = txtExportPath.Text;
			tvExcel.SelectedNode.Text = CurrentLayout.text;
		}

		private void txtSheetName_TextChanged(object sender, EventArgs e)
		{
			if (!txtSheetName.Enabled) return;
			CurrentLayout.sheet = txtSheetName.Text;
			tvExcel.SelectedNode.Text = CurrentLayout.text;
		}

		private void txtColumnName_TextChanged(object sender, EventArgs e)
		{
			if (!txtColumnName.Enabled) return;
			DB.ExcelXMLLayout.KeyPair kp = tvExcel.SelectedNode.Tag as DB.ExcelXMLLayout.KeyPair;
			kp.name = txtColumnName.Text;
			tvExcel.SelectedNode.Text = kp.text;
		}

		private void chkTypedLayout_CheckedChanged(object sender, EventArgs e)
		{
			if (!chkTypedLayout.Enabled) return;
			CurrentLayout.typed = chkTypedLayout.Checked;
		}

		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string filename = (e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString();
			string lower = filename.ToLower();

			if (lower.Contains(".xlsx") || lower.Contains(".xls"))
			{
				txtExcelPath.Text = filename;
			}
			else if (lower.Contains(".xml"))
			{
				txtExportPath.Text = filename;
			}
		}

		private void cmbAllConfig_DrawItem(object sender, DrawItemEventArgs e)
		{
			//System.Diagnostics.Debug.WriteLine(e.State);
			//if ((e.State & DrawItemState.NoFocusRect) == 0)
			//{
			//    e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
			//    e.Graphics.DrawString(cmbAllConfig.Items[e.Index].ToString(),
			//        SystemFonts.DefaultFont,
			//        Brushes.Black,
			//        e.Bounds);
			//}
			//else
			//{
			//    e.Graphics.DrawString(cmbAllConfig.Items[e.Index].ToString(),
			//        SystemFonts.DefaultFont,
			//        Brushes.Black,
			//        e.Bounds);
			//}
		}
	}
}
