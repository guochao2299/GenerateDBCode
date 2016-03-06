namespace GenerateDBCode
{
    partial class frmCompareDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompareDB));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ucDBInfo1 = new GenerateDBCode.ucDBInfo();
            this.rbFromDB1 = new System.Windows.Forms.RadioButton();
            this.rbFromFile1 = new System.Windows.Forms.RadioButton();
            this.ucDBFromXmlFile1 = new GenerateDBCode.ucDBFromXmlFile();
            this.tbcResult = new System.Windows.Forms.TabControl();
            this.tpCommon = new System.Windows.Forms.TabPage();
            this.showCommonTables = new GenerateDBCode.ucShowTables();
            this.tpUncommon = new System.Windows.Forms.TabPage();
            this.ucShowDifferentTables1 = new GenerateDBCode.ucShowDifferentTables();
            this.tpFirstUnexisted = new System.Windows.Forms.TabPage();
            this.showFirstDBUnexist = new GenerateDBCode.ucShowTables();
            this.tpSecondUnexisted = new System.Windows.Forms.TabPage();
            this.showSecondDBUnexist = new GenerateDBCode.ucShowTables();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ucDBInfo2 = new GenerateDBCode.ucDBInfo();
            this.rbFromFile2 = new System.Windows.Forms.RadioButton();
            this.rbFromDB2 = new System.Windows.Forms.RadioButton();
            this.ucDBFromXmlFile2 = new GenerateDBCode.ucDBFromXmlFile();
            this.lblInfo = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolCompare = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDBCodeFrom1To2 = new System.Windows.Forms.ToolStripButton();
            this.toolDBCodeFrom2To1 = new System.Windows.Forms.ToolStripButton();
            this.toolOutputDB1Change = new System.Windows.Forms.ToolStripButton();
            this.toolOutputDB2Change = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpCommon.SuspendLayout();
            this.tpUncommon.SuspendLayout();
            this.tpFirstUnexisted.SuspendLayout();
            this.tpSecondUnexisted.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(950, 485);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(950, 536);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbcResult, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblInfo, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 485);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(469, 143);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库一";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.ucDBInfo1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbFromDB1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbFromFile1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ucDBFromXmlFile1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(463, 123);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ucDBInfo1
            // 
            this.ucDBInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDBInfo1.Location = new System.Drawing.Point(25, 4);
            this.ucDBInfo1.Name = "ucDBInfo1";
            this.ucDBInfo1.Size = new System.Drawing.Size(434, 79);
            this.ucDBInfo1.TabIndex = 0;
            // 
            // rbFromDB1
            // 
            this.rbFromDB1.AutoSize = true;
            this.rbFromDB1.Checked = true;
            this.rbFromDB1.Location = new System.Drawing.Point(4, 4);
            this.rbFromDB1.Name = "rbFromDB1";
            this.rbFromDB1.Size = new System.Drawing.Size(14, 13);
            this.rbFromDB1.TabIndex = 0;
            this.rbFromDB1.TabStop = true;
            this.rbFromDB1.UseVisualStyleBackColor = true;
            this.rbFromDB1.CheckedChanged += new System.EventHandler(this.rbFromDB1_CheckedChanged);
            // 
            // rbFromFile1
            // 
            this.rbFromFile1.AutoSize = true;
            this.rbFromFile1.Location = new System.Drawing.Point(4, 90);
            this.rbFromFile1.Name = "rbFromFile1";
            this.rbFromFile1.Size = new System.Drawing.Size(14, 13);
            this.rbFromFile1.TabIndex = 1;
            this.rbFromFile1.UseVisualStyleBackColor = true;
            this.rbFromFile1.CheckedChanged += new System.EventHandler(this.rbFromDB1_CheckedChanged);
            // 
            // ucDBFromXmlFile1
            // 
            this.ucDBFromXmlFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDBFromXmlFile1.Enabled = false;
            this.ucDBFromXmlFile1.Location = new System.Drawing.Point(25, 90);
            this.ucDBFromXmlFile1.Name = "ucDBFromXmlFile1";
            this.ucDBFromXmlFile1.Size = new System.Drawing.Size(434, 29);
            this.ucDBFromXmlFile1.TabIndex = 2;
            // 
            // tbcResult
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbcResult, 2);
            this.tbcResult.Controls.Add(this.tpCommon);
            this.tbcResult.Controls.Add(this.tpUncommon);
            this.tbcResult.Controls.Add(this.tpFirstUnexisted);
            this.tbcResult.Controls.Add(this.tpSecondUnexisted);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(3, 152);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(944, 305);
            this.tbcResult.TabIndex = 4;
            // 
            // tpCommon
            // 
            this.tpCommon.Controls.Add(this.showCommonTables);
            this.tpCommon.Location = new System.Drawing.Point(4, 22);
            this.tpCommon.Name = "tpCommon";
            this.tpCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tpCommon.Size = new System.Drawing.Size(936, 279);
            this.tpCommon.TabIndex = 0;
            this.tpCommon.Text = "相同的结构";
            this.tpCommon.UseVisualStyleBackColor = true;
            // 
            // showCommonTables
            // 
            this.showCommonTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showCommonTables.Location = new System.Drawing.Point(3, 3);
            this.showCommonTables.Name = "showCommonTables";
            this.showCommonTables.Size = new System.Drawing.Size(930, 273);
            this.showCommonTables.TabIndex = 0;
            // 
            // tpUncommon
            // 
            this.tpUncommon.Controls.Add(this.ucShowDifferentTables1);
            this.tpUncommon.Location = new System.Drawing.Point(4, 22);
            this.tpUncommon.Name = "tpUncommon";
            this.tpUncommon.Padding = new System.Windows.Forms.Padding(3);
            this.tpUncommon.Size = new System.Drawing.Size(936, 279);
            this.tpUncommon.TabIndex = 1;
            this.tpUncommon.Text = "不同的结构";
            this.tpUncommon.UseVisualStyleBackColor = true;
            // 
            // ucShowDifferentTables1
            // 
            this.ucShowDifferentTables1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShowDifferentTables1.Location = new System.Drawing.Point(3, 3);
            this.ucShowDifferentTables1.Name = "ucShowDifferentTables1";
            this.ucShowDifferentTables1.Size = new System.Drawing.Size(930, 273);
            this.ucShowDifferentTables1.TabIndex = 0;
            // 
            // tpFirstUnexisted
            // 
            this.tpFirstUnexisted.Controls.Add(this.showFirstDBUnexist);
            this.tpFirstUnexisted.Location = new System.Drawing.Point(4, 22);
            this.tpFirstUnexisted.Name = "tpFirstUnexisted";
            this.tpFirstUnexisted.Padding = new System.Windows.Forms.Padding(3);
            this.tpFirstUnexisted.Size = new System.Drawing.Size(936, 279);
            this.tpFirstUnexisted.TabIndex = 2;
            this.tpFirstUnexisted.Text = "数据库一缺少的表";
            this.tpFirstUnexisted.UseVisualStyleBackColor = true;
            // 
            // showFirstDBUnexist
            // 
            this.showFirstDBUnexist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showFirstDBUnexist.Location = new System.Drawing.Point(3, 3);
            this.showFirstDBUnexist.Name = "showFirstDBUnexist";
            this.showFirstDBUnexist.Size = new System.Drawing.Size(930, 273);
            this.showFirstDBUnexist.TabIndex = 0;
            // 
            // tpSecondUnexisted
            // 
            this.tpSecondUnexisted.Controls.Add(this.showSecondDBUnexist);
            this.tpSecondUnexisted.Location = new System.Drawing.Point(4, 22);
            this.tpSecondUnexisted.Name = "tpSecondUnexisted";
            this.tpSecondUnexisted.Padding = new System.Windows.Forms.Padding(3);
            this.tpSecondUnexisted.Size = new System.Drawing.Size(936, 279);
            this.tpSecondUnexisted.TabIndex = 3;
            this.tpSecondUnexisted.Text = "数据库二缺少的表";
            this.tpSecondUnexisted.UseVisualStyleBackColor = true;
            // 
            // showSecondDBUnexist
            // 
            this.showSecondDBUnexist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showSecondDBUnexist.Location = new System.Drawing.Point(3, 3);
            this.showSecondDBUnexist.Name = "showSecondDBUnexist";
            this.showSecondDBUnexist.Size = new System.Drawing.Size(930, 273);
            this.showSecondDBUnexist.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(478, 3);
            this.groupBox2.Name = "groupBox2";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox2, 2);
            this.groupBox2.Size = new System.Drawing.Size(469, 143);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库二";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.ucDBInfo2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.rbFromFile2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.rbFromDB2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ucDBFromXmlFile2, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(463, 123);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // ucDBInfo2
            // 
            this.ucDBInfo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDBInfo2.Location = new System.Drawing.Point(25, 4);
            this.ucDBInfo2.Name = "ucDBInfo2";
            this.ucDBInfo2.Size = new System.Drawing.Size(434, 79);
            this.ucDBInfo2.TabIndex = 1;
            // 
            // rbFromFile2
            // 
            this.rbFromFile2.AutoSize = true;
            this.rbFromFile2.Location = new System.Drawing.Point(4, 90);
            this.rbFromFile2.Name = "rbFromFile2";
            this.rbFromFile2.Size = new System.Drawing.Size(14, 13);
            this.rbFromFile2.TabIndex = 3;
            this.rbFromFile2.UseVisualStyleBackColor = true;
            this.rbFromFile2.CheckedChanged += new System.EventHandler(this.rbFromDB2_CheckedChanged);
            // 
            // rbFromDB2
            // 
            this.rbFromDB2.AutoSize = true;
            this.rbFromDB2.Checked = true;
            this.rbFromDB2.Location = new System.Drawing.Point(4, 4);
            this.rbFromDB2.Name = "rbFromDB2";
            this.rbFromDB2.Size = new System.Drawing.Size(14, 13);
            this.rbFromDB2.TabIndex = 2;
            this.rbFromDB2.TabStop = true;
            this.rbFromDB2.UseVisualStyleBackColor = true;
            this.rbFromDB2.CheckedChanged += new System.EventHandler(this.rbFromDB2_CheckedChanged);
            // 
            // ucDBFromXmlFile2
            // 
            this.ucDBFromXmlFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDBFromXmlFile2.Enabled = false;
            this.ucDBFromXmlFile2.Location = new System.Drawing.Point(25, 90);
            this.ucDBFromXmlFile2.Name = "ucDBFromXmlFile2";
            this.ucDBFromXmlFile2.Size = new System.Drawing.Size(434, 29);
            this.ucDBFromXmlFile2.TabIndex = 4;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblInfo, 2);
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Location = new System.Drawing.Point(3, 460);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(944, 25);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCompare,
            this.toolStripSeparator1,
            this.toolDBCodeFrom1To2,
            this.toolDBCodeFrom2To1,
            this.toolOutputDB1Change,
            this.toolOutputDB2Change});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(452, 51);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolCompare
            // 
            this.toolCompare.Image = ((System.Drawing.Image)(resources.GetObject("toolCompare.Image")));
            this.toolCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCompare.Name = "toolCompare";
            this.toolCompare.Size = new System.Drawing.Size(69, 48);
            this.toolCompare.Text = "比较数据库";
            this.toolCompare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolCompare.Click += new System.EventHandler(this.toolCompare_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 51);
            this.toolStripSeparator1.Visible = false;
            // 
            // toolDBCodeFrom1To2
            // 
            this.toolDBCodeFrom1To2.Image = ((System.Drawing.Image)(resources.GetObject("toolDBCodeFrom1To2.Image")));
            this.toolDBCodeFrom1To2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDBCodeFrom1To2.Name = "toolDBCodeFrom1To2";
            this.toolDBCodeFrom1To2.Size = new System.Drawing.Size(87, 48);
            this.toolDBCodeFrom1To2.Text = "创建脚本（1）";
            this.toolDBCodeFrom1To2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolDBCodeFrom1To2.ToolTipText = "以数据库一为基础创建数据库二的增量脚本";
            this.toolDBCodeFrom1To2.Visible = false;
            this.toolDBCodeFrom1To2.Click += new System.EventHandler(this.toolDBCodeFrom1To2_Click);
            // 
            // toolDBCodeFrom2To1
            // 
            this.toolDBCodeFrom2To1.Image = ((System.Drawing.Image)(resources.GetObject("toolDBCodeFrom2To1.Image")));
            this.toolDBCodeFrom2To1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDBCodeFrom2To1.Name = "toolDBCodeFrom2To1";
            this.toolDBCodeFrom2To1.Size = new System.Drawing.Size(87, 48);
            this.toolDBCodeFrom2To1.Text = "创建脚本（2）";
            this.toolDBCodeFrom2To1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolDBCodeFrom2To1.ToolTipText = "以数据库二为基础创建数据库一的增量脚本";
            this.toolDBCodeFrom2To1.Visible = false;
            // 
            // toolOutputDB1Change
            // 
            this.toolOutputDB1Change.Image = ((System.Drawing.Image)(resources.GetObject("toolOutputDB1Change.Image")));
            this.toolOutputDB1Change.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOutputDB1Change.Name = "toolOutputDB1Change";
            this.toolOutputDB1Change.Size = new System.Drawing.Size(75, 48);
            this.toolOutputDB1Change.Text = "导出变化(1)";
            this.toolOutputDB1Change.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolOutputDB1Change.ToolTipText = "将数据库一中的变化导成文本";
            this.toolOutputDB1Change.Click += new System.EventHandler(this.toolOutputDB1Change_Click);
            // 
            // toolOutputDB2Change
            // 
            this.toolOutputDB2Change.Image = ((System.Drawing.Image)(resources.GetObject("toolOutputDB2Change.Image")));
            this.toolOutputDB2Change.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOutputDB2Change.Name = "toolOutputDB2Change";
            this.toolOutputDB2Change.Size = new System.Drawing.Size(87, 48);
            this.toolOutputDB2Change.Text = "导出变化（2）";
            this.toolOutputDB2Change.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolOutputDB2Change.ToolTipText = "将数据库二中的变化导成文本";
            // 
            // frmCompareDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 536);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmCompareDB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCompareDB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCompareDB_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpCommon.ResumeLayout(false);
            this.tpUncommon.ResumeLayout(false);
            this.tpFirstUnexisted.ResumeLayout(false);
            this.tpSecondUnexisted.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ucDBInfo ucDBInfo1;
        private ucDBInfo ucDBInfo2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolCompare;
        private System.Windows.Forms.TabControl tbcResult;
        private System.Windows.Forms.TabPage tpCommon;
        private System.Windows.Forms.TabPage tpUncommon;
        private ucShowTables showCommonTables;
        private System.Windows.Forms.TabPage tpFirstUnexisted;
        private ucShowTables showFirstDBUnexist;
        private System.Windows.Forms.TabPage tpSecondUnexisted;
        private ucShowTables showSecondDBUnexist;
        private ucShowDifferentTables ucShowDifferentTables1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolDBCodeFrom1To2;
        private System.Windows.Forms.ToolStripButton toolDBCodeFrom2To1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rbFromDB1;
        private System.Windows.Forms.RadioButton rbFromFile1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton rbFromFile2;
        private System.Windows.Forms.RadioButton rbFromDB2;
        private ucDBFromXmlFile ucDBFromXmlFile1;
        private ucDBFromXmlFile ucDBFromXmlFile2;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ToolStripButton toolOutputDB1Change;
        private System.Windows.Forms.ToolStripButton toolOutputDB2Change;
    }
}