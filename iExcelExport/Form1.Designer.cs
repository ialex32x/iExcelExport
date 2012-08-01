namespace iExcelExport
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tvExcel = new System.Windows.Forms.TreeView();
			this.ilExcelTree = new System.Windows.Forms.ImageList(this.components);
			this.ctxExport = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.导出XMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.猜测格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.添加新数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSave = new System.Windows.Forms.Button();
			this.txtItemName = new System.Windows.Forms.TextBox();
			this.txtSummary = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtExcelPath = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtExcelName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtExportPath = new System.Windows.Forms.TextBox();
			this.txtSheetName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkTypedLayout = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.ctxKeyPair = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.整数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.字符串ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.删除此数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxBatchExport = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.全部导出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.添加LayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtColumnName = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ctxAllExcel = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.导出所有ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.添加ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmbAllConfig = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.ctxExport.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.ctxKeyPair.SuspendLayout();
			this.ctxBatchExport.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.ctxAllExcel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvExcel
			// 
			this.tvExcel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvExcel.HideSelection = false;
			this.tvExcel.ImageIndex = 0;
			this.tvExcel.ImageList = this.ilExcelTree;
			this.tvExcel.Location = new System.Drawing.Point(0, 0);
			this.tvExcel.Name = "tvExcel";
			this.tvExcel.SelectedImageIndex = 0;
			this.tvExcel.Size = new System.Drawing.Size(289, 353);
			this.tvExcel.TabIndex = 0;
			this.tvExcel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvExcel_AfterSelect);
			this.tvExcel.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvExcel_NodeMouseClick);
			// 
			// ilExcelTree
			// 
			this.ilExcelTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilExcelTree.ImageStream")));
			this.ilExcelTree.TransparentColor = System.Drawing.Color.Transparent;
			this.ilExcelTree.Images.SetKeyName(0, "ROOT");
			this.ilExcelTree.Images.SetKeyName(1, "LAYOUT");
			this.ilExcelTree.Images.SetKeyName(2, "KEYPAIR");
			this.ilExcelTree.Images.SetKeyName(3, "EXCEL");
			// 
			// ctxExport
			// 
			this.ctxExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出XMLToolStripMenuItem,
            this.toolStripMenuItem1,
            this.猜测格式ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.添加新数据ToolStripMenuItem});
			this.ctxExport.Name = "ctxExport";
			this.ctxExport.Size = new System.Drawing.Size(153, 104);
			// 
			// 导出XMLToolStripMenuItem
			// 
			this.导出XMLToolStripMenuItem.Name = "导出XMLToolStripMenuItem";
			this.导出XMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.导出XMLToolStripMenuItem.Text = "导出XML(&X)";
			this.导出XMLToolStripMenuItem.Click += new System.EventHandler(this.导出XMLToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// 猜测格式ToolStripMenuItem
			// 
			this.猜测格式ToolStripMenuItem.Name = "猜测格式ToolStripMenuItem";
			this.猜测格式ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.猜测格式ToolStripMenuItem.Text = "猜测格式(&G)";
			this.猜测格式ToolStripMenuItem.Click += new System.EventHandler(this.猜测格式ToolStripMenuItem_Click);
			// 
			// 删除ToolStripMenuItem
			// 
			this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
			this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.删除ToolStripMenuItem.Text = "删除(&D)";
			this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
			// 
			// 添加新数据ToolStripMenuItem
			// 
			this.添加新数据ToolStripMenuItem.Name = "添加新数据ToolStripMenuItem";
			this.添加新数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.添加新数据ToolStripMenuItem.Text = "添加新数据(&A)";
			this.添加新数据ToolStripMenuItem.Click += new System.EventHandler(this.添加新数据ToolStripMenuItem_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(5, 324);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "保存(&S)";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtItemName
			// 
			this.txtItemName.Enabled = false;
			this.txtItemName.Location = new System.Drawing.Point(65, 23);
			this.txtItemName.Name = "txtItemName";
			this.txtItemName.Size = new System.Drawing.Size(100, 21);
			this.txtItemName.TabIndex = 3;
			this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
			// 
			// txtSummary
			// 
			this.txtSummary.Enabled = false;
			this.txtSummary.Location = new System.Drawing.Point(65, 50);
			this.txtSummary.Name = "txtSummary";
			this.txtSummary.Size = new System.Drawing.Size(301, 21);
			this.txtSummary.TabIndex = 4;
			this.txtSummary.TextChanged += new System.EventHandler(this.txtSummary_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "备注";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "元素名";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtExcelPath);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtExcelName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(3, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(372, 103);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Excel";
			// 
			// txtExcelPath
			// 
			this.txtExcelPath.Enabled = false;
			this.txtExcelPath.Location = new System.Drawing.Point(20, 65);
			this.txtExcelPath.Name = "txtExcelPath";
			this.txtExcelPath.Size = new System.Drawing.Size(348, 21);
			this.txtExcelPath.TabIndex = 3;
			this.txtExcelPath.TextChanged += new System.EventHandler(this.txtExcelPath_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 50);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 12);
			this.label5.TabIndex = 5;
			this.label5.Text = "Excel文件";
			// 
			// txtExcelName
			// 
			this.txtExcelName.Enabled = false;
			this.txtExcelName.Location = new System.Drawing.Point(65, 20);
			this.txtExcelName.Name = "txtExcelName";
			this.txtExcelName.Size = new System.Drawing.Size(301, 21);
			this.txtExcelName.TabIndex = 3;
			this.txtExcelName.TextChanged += new System.EventHandler(this.txtExcelName_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = "备注";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtExportPath);
			this.groupBox2.Controls.Add(this.txtSheetName);
			this.groupBox2.Controls.Add(this.txtItemName);
			this.groupBox2.Controls.Add(this.txtSummary);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.chkTypedLayout);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(3, 121);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(372, 135);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "XML";
			// 
			// txtExportPath
			// 
			this.txtExportPath.Enabled = false;
			this.txtExportPath.Location = new System.Drawing.Point(20, 95);
			this.txtExportPath.Name = "txtExportPath";
			this.txtExportPath.Size = new System.Drawing.Size(346, 21);
			this.txtExportPath.TabIndex = 3;
			this.txtExportPath.TextChanged += new System.EventHandler(this.txtExportPath_TextChanged);
			// 
			// txtSheetName
			// 
			this.txtSheetName.Enabled = false;
			this.txtSheetName.Location = new System.Drawing.Point(266, 23);
			this.txtSheetName.Name = "txtSheetName";
			this.txtSheetName.Size = new System.Drawing.Size(100, 21);
			this.txtSheetName.TabIndex = 3;
			this.txtSheetName.TextChanged += new System.EventHandler(this.txtSheetName_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "导出XML文件";
			// 
			// chkTypedLayout
			// 
			this.chkTypedLayout.AutoSize = true;
			this.chkTypedLayout.Enabled = false;
			this.chkTypedLayout.Location = new System.Drawing.Point(266, 79);
			this.chkTypedLayout.Name = "chkTypedLayout";
			this.chkTypedLayout.Size = new System.Drawing.Size(102, 16);
			this.chkTypedLayout.TabIndex = 8;
			this.chkTypedLayout.Text = "带 type 的XML";
			this.chkTypedLayout.UseVisualStyleBackColor = true;
			this.chkTypedLayout.CheckedChanged += new System.EventHandler(this.chkTypedLayout_CheckedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(213, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 12);
			this.label6.TabIndex = 5;
			this.label6.Text = "Sheet名";
			// 
			// ctxKeyPair
			// 
			this.ctxKeyPair.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.整数ToolStripMenuItem,
            this.字符串ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.删除此数据ToolStripMenuItem});
			this.ctxKeyPair.Name = "ctxKeyPair";
			this.ctxKeyPair.Size = new System.Drawing.Size(154, 76);
			// 
			// 整数ToolStripMenuItem
			// 
			this.整数ToolStripMenuItem.Name = "整数ToolStripMenuItem";
			this.整数ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.整数ToolStripMenuItem.Text = "整数(&1)";
			this.整数ToolStripMenuItem.Click += new System.EventHandler(this.整数ToolStripMenuItem_Click);
			// 
			// 字符串ToolStripMenuItem
			// 
			this.字符串ToolStripMenuItem.Name = "字符串ToolStripMenuItem";
			this.字符串ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.字符串ToolStripMenuItem.Text = "文本(&3)";
			this.字符串ToolStripMenuItem.Click += new System.EventHandler(this.字符串ToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(150, 6);
			// 
			// 删除此数据ToolStripMenuItem
			// 
			this.删除此数据ToolStripMenuItem.Name = "删除此数据ToolStripMenuItem";
			this.删除此数据ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.删除此数据ToolStripMenuItem.Text = "删除此数据(&D)";
			this.删除此数据ToolStripMenuItem.Click += new System.EventHandler(this.删除此数据ToolStripMenuItem_Click);
			// 
			// ctxBatchExport
			// 
			this.ctxBatchExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全部导出XToolStripMenuItem,
            this.toolStripMenuItem2,
            this.添加LayoutToolStripMenuItem,
            this.删除ExcelToolStripMenuItem});
			this.ctxBatchExport.Name = "ctxBatchExport";
			this.ctxBatchExport.Size = new System.Drawing.Size(155, 98);
			// 
			// 全部导出XToolStripMenuItem
			// 
			this.全部导出XToolStripMenuItem.Name = "全部导出XToolStripMenuItem";
			this.全部导出XToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.全部导出XToolStripMenuItem.Text = "全部导出(&X)";
			this.全部导出XToolStripMenuItem.Click += new System.EventHandler(this.全部导出XToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 6);
			// 
			// 添加LayoutToolStripMenuItem
			// 
			this.添加LayoutToolStripMenuItem.Name = "添加LayoutToolStripMenuItem";
			this.添加LayoutToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.添加LayoutToolStripMenuItem.Text = "添加Layout(&A)";
			this.添加LayoutToolStripMenuItem.Click += new System.EventHandler(this.添加LayoutToolStripMenuItem_Click);
			// 
			// 删除ExcelToolStripMenuItem
			// 
			this.删除ExcelToolStripMenuItem.Name = "删除ExcelToolStripMenuItem";
			this.删除ExcelToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.删除ExcelToolStripMenuItem.Text = "删除Excel(&D)";
			this.删除ExcelToolStripMenuItem.Click += new System.EventHandler(this.删除ExcelToolStripMenuItem_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtColumnName);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Location = new System.Drawing.Point(4, 262);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(371, 58);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "数据";
			// 
			// txtColumnName
			// 
			this.txtColumnName.Enabled = false;
			this.txtColumnName.Location = new System.Drawing.Point(64, 24);
			this.txtColumnName.Name = "txtColumnName";
			this.txtColumnName.Size = new System.Drawing.Size(100, 21);
			this.txtColumnName.TabIndex = 6;
			this.txtColumnName.TextChanged += new System.EventHandler(this.txtColumnName_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(17, 27);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 12);
			this.label7.TabIndex = 5;
			this.label7.Text = "名字";
			// 
			// ctxAllExcel
			// 
			this.ctxAllExcel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出所有ExcelToolStripMenuItem,
            this.toolStripMenuItem5,
            this.添加ExcelToolStripMenuItem});
			this.ctxAllExcel.Name = "ctxAllExcel";
			this.ctxAllExcel.Size = new System.Drawing.Size(170, 54);
			// 
			// 导出所有ExcelToolStripMenuItem
			// 
			this.导出所有ExcelToolStripMenuItem.Name = "导出所有ExcelToolStripMenuItem";
			this.导出所有ExcelToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.导出所有ExcelToolStripMenuItem.Text = "导出所有Excel(&X)";
			this.导出所有ExcelToolStripMenuItem.Click += new System.EventHandler(this.导出所有ExcelToolStripMenuItem_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(166, 6);
			// 
			// 添加ExcelToolStripMenuItem
			// 
			this.添加ExcelToolStripMenuItem.Name = "添加ExcelToolStripMenuItem";
			this.添加ExcelToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.添加ExcelToolStripMenuItem.Text = "添加Excel(&A)";
			this.添加ExcelToolStripMenuItem.Click += new System.EventHandler(this.添加ExcelToolStripMenuItem_Click);
			// 
			// cmbAllConfig
			// 
			this.cmbAllConfig.FormattingEnabled = true;
			this.cmbAllConfig.Location = new System.Drawing.Point(187, 326);
			this.cmbAllConfig.Name = "cmbAllConfig";
			this.cmbAllConfig.Size = new System.Drawing.Size(182, 20);
			this.cmbAllConfig.TabIndex = 8;
			this.cmbAllConfig.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbAllConfig_DrawItem);
			this.cmbAllConfig.SelectedIndexChanged += new System.EventHandler(this.cmbAllConfig_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(128, 329);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 12);
			this.label8.TabIndex = 5;
			this.label8.Text = "其他配置";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tvExcel);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel2.Controls.Add(this.btnSave);
			this.splitContainer1.Panel2.Controls.Add(this.label8);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Panel2.Controls.Add(this.cmbAllConfig);
			this.splitContainer1.Size = new System.Drawing.Size(675, 353);
			this.splitContainer1.SplitterDistance = 289;
			this.splitContainer1.TabIndex = 9;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(675, 353);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "表格导出工具";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.ctxExport.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ctxKeyPair.ResumeLayout(false);
			this.ctxBatchExport.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ctxAllExcel.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView tvExcel;
		private System.Windows.Forms.ContextMenuStrip ctxExport;
		private System.Windows.Forms.ToolStripMenuItem 导出XMLToolStripMenuItem;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtItemName;
		private System.Windows.Forms.TextBox txtSummary;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtExportPath;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtExcelPath;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtExcelName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 猜测格式ToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip ctxKeyPair;
		private System.Windows.Forms.ToolStripMenuItem 整数ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 字符串ToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip ctxBatchExport;
		private System.Windows.Forms.ToolStripMenuItem 全部导出XToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem 添加LayoutToolStripMenuItem;
		private System.Windows.Forms.TextBox txtSheetName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem 添加新数据ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem 删除此数据ToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtColumnName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox chkTypedLayout;
		private System.Windows.Forms.ContextMenuStrip ctxAllExcel;
		private System.Windows.Forms.ToolStripMenuItem 添加ExcelToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem 导出所有ExcelToolStripMenuItem;
		private System.Windows.Forms.ImageList ilExcelTree;
		private System.Windows.Forms.ComboBox cmbAllConfig;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ToolStripMenuItem 删除ExcelToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}

