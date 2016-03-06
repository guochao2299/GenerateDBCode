using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenerateDBCode
{
    public partial class ucDBInfo : UserControl
    {
        public ucDBInfo()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public string CheckDBInfo()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(txtServer.Text))
            {
                sb.Append("服务器名称不能为空;");
            }

            if (string.IsNullOrEmpty(txtDB.Text))
            {
                sb.Append("数据库名称不能为空;");
            }

            if (string.IsNullOrEmpty(txtUser.Text))
            {
                sb.Append("用户ID不能为空;");
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                sb.Append("密码不能为空;");
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                sb.Append("数据库类型不能为空");
            }

            return sb.Length > 0 ? sb.ToString().TrimEnd(';') : string.Empty;
        }

        public void SetDBInfo(string server, string dbName, string userID, string password)
        {
            this.txtDB.Text = dbName;
            this.txtPassword.Text = password;
            this.txtServer.Text = server;
            this.txtUser.Text = userID;
        }

        public string DBName
        {
            get
            {
                return txtDB.Text;
            }
        }

        public string ConnectionString
        {
            get
            {
                return string.Format("data source={0};initial catalog={1};User ID={2};Password={3}", new object[] { txtServer.Text, txtDB.Text, txtUser.Text, txtPassword.Text });
            }
        }

        public string SqlDBType
        {
            get
            {
                return this.comboBox1.Text;
            }
        }

        private void ucDBInfo_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();

            foreach (string s in SqlDBQueryableBase.SupportedSqlDB)
            {
                this.comboBox1.Items.Add(s);
            }

            if (this.comboBox1.Items.Count > 0)
            {
                this.comboBox1.SelectedIndex = 0;
            }
        }

    }
}
