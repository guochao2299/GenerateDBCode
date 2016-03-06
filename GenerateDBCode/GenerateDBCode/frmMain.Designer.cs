namespace GenerateDBCode
{
    partial class frmMain
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnSave2Xml = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbFromDB1 = new System.Windows.Forms.RadioButton();
            this.rbFromFile1 = new System.Windows.Forms.RadioButton();
            this.ucDBInfo1 = new GenerateDBCode.ucDBInfo();
            this.ucDBFromXmlFile1 = new GenerateDBCode.ucDBFromXmlFile();
            this.ucShowTables1 = new GenerateDBCode.ucShowTables();
            this.btnAbout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnAbout);
            this.splitContainer1.Panel1.Controls.Add(this.btnCompare);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave2Xml);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerate);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucShowTables1);
            this.splitContainer1.Size = new System.Drawing.Size(978, 452);
            this.splitContainer1.SplitterDistance = 152;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(781, 23);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(107, 23);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "数据库结构比较";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnSave2Xml
            // 
            this.btnSave2Xml.Location = new System.Drawing.Point(626, 64);
            this.btnSave2Xml.Name = "btnSave2Xml";
            this.btnSave2Xml.Size = new System.Drawing.Size(102, 23);
            this.btnSave2Xml.TabIndex = 3;
            this.btnSave2Xml.Text = "保存数据库结构";
            this.btnSave2Xml.UseVisualStyleBackColor = true;
            this.btnSave2Xml.Click += new System.EventHandler(this.btnSave2Xml_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(626, 109);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(102, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "生成映射文件";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(626, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新数据库";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 146);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库信息";
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(560, 126);
            this.tableLayoutPanel2.TabIndex = 1;
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
            this.rbFromFile1.Location = new System.Drawing.Point(4, 93);
            this.rbFromFile1.Name = "rbFromFile1";
            this.rbFromFile1.Size = new System.Drawing.Size(14, 13);
            this.rbFromFile1.TabIndex = 1;
            this.rbFromFile1.UseVisualStyleBackColor = true;
            this.rbFromFile1.CheckedChanged += new System.EventHandler(this.rbFromDB1_CheckedChanged);
            // 
            // ucDBInfo1
            // 
            this.ucDBInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDBInfo1.Location = new System.Drawing.Point(25, 4);
            this.ucDBInfo1.Name = "ucDBInfo1";
            this.ucDBInfo1.Size = new System.Drawing.Size(531, 82);
            this.ucDBInfo1.TabIndex = 0;
            // 
            // ucDBFromXmlFile1
            // 
            this.ucDBFromXmlFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDBFromXmlFile1.Enabled = false;
            this.ucDBFromXmlFile1.Location = new System.Drawing.Point(25, 93);
            this.ucDBFromXmlFile1.Name = "ucDBFromXmlFile1";
            this.ucDBFromXmlFile1.Size = new System.Drawing.Size(531, 29);
            this.ucDBFromXmlFile1.TabIndex = 2;
            // 
            // ucShowTables1
            // 
            this.ucShowTables1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShowTables1.Location = new System.Drawing.Point(0, 0);
            this.ucShowTables1.Name = "ucShowTables1";
            this.ucShowTables1.Size = new System.Drawing.Size(978, 296);
            this.ucShowTables1.TabIndex = 0;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(781, 64);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(107, 23);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "关于...";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 452);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "创建表映射对象";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnSave2Xml;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ucDBInfo ucDBInfo1;
        private System.Windows.Forms.RadioButton rbFromDB1;
        private System.Windows.Forms.RadioButton rbFromFile1;
        private ucDBFromXmlFile ucDBFromXmlFile1;
        private ucShowTables ucShowTables1;
        private System.Windows.Forms.Button btnAbout;
    }
}

