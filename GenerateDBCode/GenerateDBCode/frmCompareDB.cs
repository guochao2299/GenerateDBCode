﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GenerateDBCode
{
    public partial class frmCompareDB : Form
    {
        private class DBCompareResult
        {
            public Dictionary<string, MyTable> dbFirstNonexistTables=null;
            public Dictionary<string, MyTable> dbSecondNonexistTables=null;
            public Dictionary<string, List<MyTableBase>> dbUncommonTables=null;

            public Dictionary<string, MyView> dbFirstNonexistViews=null;
            public Dictionary<string, MyView> dbSecondNonexistViews = null;
            public Dictionary<string, List<MyTableBase>> dbUncommonViews = null;
        }

        public frmCompareDB()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        private MyDatabase GetDBStruct(ucDBInfo db)
        {
            ISqlDBQueryable sqlDB = SqlDBQueryableBase.CreateQueryableSqlDB(db.SqlDBType, db.ConnectionString);
            return sqlDB.QueryDBInfo(db.DBName);
        }

        private void FindDifferenceBetweenDB<T>(Dictionary<string, T> firstDBTables, Dictionary<string, T> secondDBTables,
            out Dictionary<string, T> dbFirstNonexistTables, out Dictionary<string, T> dbSecondNonexistTables,
            out Dictionary<string, T> dbCommonTables, out Dictionary<string, List<MyTableBase>> dbUncommonTables)
            where T:MyTableBase,IPropertyEqual
        {
            dbFirstNonexistTables = new Dictionary<string, T>();
            dbSecondNonexistTables = new Dictionary<string, T>();
            dbCommonTables = new Dictionary<string, T>();
            dbUncommonTables = new Dictionary<string, List<MyTableBase>>();

            foreach (string tableName in firstDBTables.Keys)
            {
#if DEBUG
                Console.WriteLine(tableName);
#endif
                if (secondDBTables.ContainsKey(tableName))
                {
                    if (firstDBTables[tableName].PropertyEqual(secondDBTables[tableName]))
                    {
                        dbCommonTables.Add(tableName, firstDBTables[tableName]);
                    }
                    else
                    {
                        List<MyTableBase> lstTables = new List<MyTableBase>();
                        lstTables.Add(firstDBTables[tableName]);
                        lstTables.Add(secondDBTables[tableName]);

                        dbUncommonTables.Add(tableName, lstTables);
                    }
                }
                else
                {
                    dbSecondNonexistTables.Add(tableName, firstDBTables[tableName]);
                }
            }

            foreach (string tableName in secondDBTables.Keys)
            {
                if (!firstDBTables.ContainsKey(tableName))
                {
                    dbFirstNonexistTables.Add(tableName, secondDBTables[tableName]);
                }
            }
        }

        private bool CheckDBSettings()
        {
            string checkResult = string.Empty;

            if (rbFromDB1.Checked)
            {
                checkResult = this.ucDBInfo1.CheckDBInfo();
                if (!string.IsNullOrEmpty(checkResult))
                {
                    MessageBox.Show("数据库一的设置不对，错误消息为：" + checkResult);
                    this.ucDBInfo1.Focus();
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.ucDBFromXmlFile1.DBXmlFilePath))
                {
                    MessageBox.Show("请先选择包含数据库一结构的xml文件");
                    this.ucDBFromXmlFile1.Focus();
                    return false;
                }
            }

            if (rbFromDB2.Checked)
            {
                checkResult = this.ucDBInfo2.CheckDBInfo();
                if (!string.IsNullOrEmpty(checkResult))
                {
                    MessageBox.Show("数据库二的设置不对，错误消息为：" + checkResult);
                    this.ucDBInfo2.Focus();
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.ucDBFromXmlFile2.DBXmlFilePath))
                {
                    MessageBox.Show("请先选择包含数据库二结构的xml文件");
                    this.ucDBFromXmlFile2.Focus();
                    return false;
                }
            }             

            return true;
        }

        private void RePackUpDBBase(MyDatabase db, out Dictionary<string, MyTable> tables, out Dictionary<string, MyView> views)
        {
            tables = new Dictionary<string, MyTable>();
            views = new Dictionary<string, MyView>();

            foreach (MyTable t in db.Tables.Values)
            {
                tables.Add(t.Name, t);
            }

            foreach (MyView v in db.Views.Values)
            {
                views.Add(v.Name, v);
            }
        }

        private void ShowCompareInfo(string info)
        {
            lblInfo.Text = info;
        }

        private void toolCompare_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                ShowCompareInfo(string.Empty);

                if (!CheckDBSettings())
                {
                    return;
                }

                // 这里需要对表进行重新整理，便于数据比较
                ShowCompareInfo("开始加载数据库一的结构");

                MyDatabase dbFirst=null; 
                if(rbFromDB1.Checked)
                {
                    dbFirst=GetDBStruct(this.ucDBInfo1);
                }
                else
                { 
                    dbFirst=MyDatabase.ReadDBStructFromXMLFile(this.ucDBFromXmlFile1.DBXmlFilePath);
                }

                ShowCompareInfo("开始加载数据库二的结构");

                MyDatabase dbSecond=null; 
                if(rbFromDB2.Checked)
                {
                    dbSecond=GetDBStruct(this.ucDBInfo2);
                }
                else
                {
                    dbSecond = MyDatabase.ReadDBStructFromXMLFile(this.ucDBFromXmlFile2.DBXmlFilePath);
                }

                ShowCompareInfo("开始对数据库一结构进行整理");
                Dictionary<string,MyTable> firstDBTables=null;
                Dictionary<string, MyView>  firstDBViews=null;
                RePackUpDBBase(dbFirst, out firstDBTables, out firstDBViews);

                ShowCompareInfo("开始对数据库二结构进行整理");
                Dictionary<string,MyTable> secondDBTables=null;
                Dictionary<string,MyView> secondDBViews=null;
                RePackUpDBBase(dbSecond, out secondDBTables, out secondDBViews);

                ShowCompareInfo("开始对数据库结构进行对比");
                DBCompareResult result = new DBCompareResult();

                ShowCompareInfo("开始对数据库中表结构进行对比");
                Dictionary<string,MyTable> dbCommonTables;
                FindDifferenceBetweenDB<MyTable>(firstDBTables,secondDBTables,
                    out result.dbFirstNonexistTables, out result.dbSecondNonexistTables,
                    out dbCommonTables, out result.dbUncommonTables);

                ShowCompareInfo("开始对数据库中视图结构进行对比");
                Dictionary<string, MyView> dbCommonViews;
                FindDifferenceBetweenDB<MyView>(firstDBViews, secondDBViews,
                    out result.dbFirstNonexistViews, out result.dbSecondNonexistViews,
                    out dbCommonViews, out result.dbUncommonViews);

                ShowCompareInfo("开始显示数据库对比结果");

                // 将处理好的数据放置的tabcontrol中
                ShowCompareInfo("开始填充数据库相同结构");
                showCommonTables.SetTables(dbCommonTables.Values);
                showCommonTables.AppendTables(dbCommonViews.Values);

                ShowCompareInfo("开始填充各数据库一中缺少的结构");
                showFirstDBUnexist.SetTables(result.dbFirstNonexistTables.Values);
                showFirstDBUnexist.AppendTables(result.dbFirstNonexistViews.Values);

                ShowCompareInfo("开始填充各数据库二中缺少的结构");
                showSecondDBUnexist.SetTables(result.dbSecondNonexistTables.Values);
                showSecondDBUnexist.AppendTables(result.dbSecondNonexistViews.Values);

                ShowCompareInfo("开始填充各数据库中存在差异的结构");
                ucShowDifferentTables1.SetTables(result.dbUncommonTables);
                ucShowDifferentTables1.AppendTables(result.dbUncommonViews);

                toolCompare.Tag = result;
            }
            catch (Exception ex)
            {
                string msg = "比较数据库结构失败，错误消息为:" + ex.Message;
                ShowCompareInfo(msg);
                MessageBox.Show(msg);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmCompareDB_Load(object sender, EventArgs e)
        {
        }

        private void toolDBCodeFrom1To2_Click(object sender, EventArgs e)
        {
            if(toolCompare.Tag ==null ||!(toolCompare.Tag is DBCompareResult))
            {
                MessageBox.Show("请先点击数据库比较按钮进行数据库结构比较");
                return;
            }
                        
            DBCompareResult result=(DBCompareResult)toolCompare.Tag;

            bool isChangeExisted=result.dbSecondNonexistTables.Count > 0 || result.dbUncommonTables.Count>0 || result.dbUncommonViews.Count>0;

            if (!isChangeExisted)
            {
                MessageBox.Show("数据库二相对于数据库一没有变化，不需要生成脚本");
                return;
            }

            SaveFileDialog sfd=new SaveFileDialog();
            sfd.FileName="DB2 change.txt";
            sfd.Filter="文本文档|*.txt";

            if(sfd.ShowDialog(this)!= System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            this.Cursor=Cursors.WaitCursor;
            FileStream fs=null;

            try
            {
                if(result.dbSecondNonexistTables.Count>0)
                {

                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show("创建数据库二变化脚本失败，错误消息为："+ex.Message);
            }
            finally
            {
                if(fs!=null)
                {
                    fs.Close();
                }

                this.Cursor=Cursors.Default;
            }
            //if(result.dbSecondNonexistTables
        }

        private void rbFromDB1_CheckedChanged(object sender, EventArgs e)
        {
            this.ucDBInfo1.Enabled = rbFromDB1.Checked;
            this.ucDBFromXmlFile1.Enabled = !this.ucDBInfo1.Enabled;
        }

        private void rbFromDB2_CheckedChanged(object sender, EventArgs e)
        {
            this.ucDBInfo2.Enabled = rbFromDB2.Checked;
            this.ucDBFromXmlFile2.Enabled = !this.ucDBInfo2.Enabled;
        }

        private void toolOutputDB1Change_Click(object sender, EventArgs e)
        {
            if (toolCompare.Tag == null)
            {
                MessageBox.Show("请先进行数据库比较");
                return;
            }

            DBCompareResult result = (DBCompareResult)toolCompare.Tag;

            StringBuilder sb = new StringBuilder();
            if (result.dbFirstNonexistTables.Count > 0)
            {
                sb.AppendLine("不存在的表：");

                foreach (string s in result.dbFirstNonexistTables.Keys)
                {
                    sb.AppendLine("\t" + s);
                }
            }

            if (result.dbFirstNonexistViews.Count > 0)
            {
                sb.AppendLine("不存在的视图：");

                foreach (string s in result.dbFirstNonexistViews.Keys)
                {
                    sb.AppendLine("\t" + s);
                }
            }

            if (result.dbUncommonTables.Count>0)
            {
                sb.AppendLine("定义不同的表：");

                foreach (string s in result.dbUncommonTables.Keys)
                {
                    sb.AppendLine(string.Format("\t表{0}的定义:", s));
                    sb.AppendLine("\t" + ucShowDifferentTables.CompareTables(result.dbUncommonTables[s][0], result.dbUncommonTables[s][1],true));
                }                
            }

            if (result.dbUncommonViews.Count > 0)
            {
                sb.AppendLine("定义不同的视图：");

                foreach (string s in result.dbUncommonViews.Keys)
                {
                    sb.AppendLine(string.Format("\t视图{0}的定义:", s));
                    sb.AppendLine("\t" + ucShowDifferentTables.CompareTables(result.dbUncommonViews[s][0], result.dbUncommonViews[s][1], true));
                }
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt";
            sfd.FileName = "数据库一中的变化.txt";

            if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fs = null;
                TextWriter tw = null;
                try
                {
                    fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    tw = new StreamWriter(fs);
                    tw.Write(sb.ToString());                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存文件失败，错误消息为：" + ex.Message);
                }
                finally
                {
                    if (tw != null)
                    {
                        tw.Close();
                    }

                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
        }

    }
}
