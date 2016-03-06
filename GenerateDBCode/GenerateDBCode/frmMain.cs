using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Threading;

namespace GenerateDBCode
{
    public partial class frmMain : Form
    {
        private MyDatabase m_currentDB = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {            
            InitTables();
        }

        private string ConnectionString
        {
            get
            {
                return this.ucDBInfo1.ConnectionString;
            }
        }

        private const string TABLE_SIGN = "U";
        private const string VIEW_SIGN = "V";
        private const string TABLE_STRING = "表";
        private const string VIEW_STRING = "视图";

        private void InitTables()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.ucShowTables1.SuspendLayout();

                if (rbFromDB1.Checked)
                {
                    string result = this.ucDBInfo1.CheckDBInfo();

                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show(result);
                        ucDBInfo1.Focus();
                        return;
                    }

                    ISqlDBQueryable sqldb = SqlDBQueryableBase.CreateQueryableSqlDB(this.ucDBInfo1.SqlDBType, this.ucDBInfo1.ConnectionString);
                    m_currentDB = sqldb.QueryDBInfo(this.ucDBInfo1.DBName);
                }
                else
                {
                    if (string.IsNullOrEmpty(this.ucDBFromXmlFile1.DBXmlFilePath))
                    {
                        MessageBox.Show("请先选择包含数据库结构的xml文件");
                        this.ucDBFromXmlFile1.Focus();
                        return;
                    }

                    m_currentDB = MyDatabase.ReadDBStructFromXMLFile(this.ucDBFromXmlFile1.DBXmlFilePath);
                }

                this.ucShowTables1.SetTables(m_currentDB.Tables.Values);
                this.ucShowTables1.AppendTables(m_currentDB.Views.Values);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("检索数据库表失败，错误消息为：" + ex.Message);
            }
            finally
            {
                this.ucShowTables1.ResumeLayout();

                this.Cursor = Cursors.Default;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ucDBInfo1.SetDBInfo("capp-test", "SystemMaintance", "apuser", "Abc1234567");
        }       

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (m_currentDB == null)
                {
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("生成数据库映射文件失败，错误消息为：" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private class FileSaveInfo
        {
             public ISqlDBQueryable Sqldb=null;
             public string FilePath = string.Empty;
             public string DBName = string.Empty;
        }
        private void SaveDBStruct2XMLFile(object info)
        {
            try
            {
                if ((info == null) || !(info is FileSaveInfo) || (m_currentDB==null))
                {
                    return;
                }

                ISqlDBQueryable sqldb = ((FileSaveInfo)info).Sqldb;
                string filePath = ((FileSaveInfo)info).FilePath;
                MyDatabase myDB = sqldb.QueryDBInfo(((FileSaveInfo)info).DBName);

                myDB.SaveDBStruct2XMLFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("将数据库结构另存为文件失败，错误消息为：" + ex.Message);
            }            
        }
        private void btnSave2Xml_Click(object sender, EventArgs e)
        {            
            try
            {
                this.Cursor=Cursors.WaitCursor;

                string result = this.ucDBInfo1.CheckDBInfo();

                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(result);
                    ucDBInfo1.Focus();
                    return;
                }                

                SaveFileDialog sfd=new SaveFileDialog();
                sfd.FileName = string.Format("{0}.xml", this.ucDBInfo1.DBName);
                sfd.Filter="XML文件|*.xml";
                
                if(sfd.ShowDialog(this)== System.Windows.Forms.DialogResult.OK)
                {
                    FileSaveInfo info=new FileSaveInfo();
                    info.FilePath=sfd.FileName;
                    info.DBName = this.ucDBInfo1.DBName;
                    info.Sqldb = SqlDBQueryableBase.CreateQueryableSqlDB(this.ucDBInfo1.SqlDBType, this.ucDBInfo1.ConnectionString);

                    ThreadPool.QueueUserWorkItem(new WaitCallback(SaveDBStruct2XMLFile), info);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("将数据库结构另存为文件失败，错误消息为："+ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            frmCompareDB cf = new frmCompareDB();
            cf.ShowDialog(this);
        }

        private void rbFromDB1_CheckedChanged(object sender, EventArgs e)
        {
            this.ucDBInfo1.Enabled = rbFromDB1.Checked;
            this.ucDBFromXmlFile1.Enabled = !this.ucDBInfo1.Enabled;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Designer:gchao");
            sb.AppendLine("Programmer:gchao");
            sb.AppendLine("Version:" + Application.ProductVersion);
  
            MessageBox.Show(this,sb.ToString(),"About",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
