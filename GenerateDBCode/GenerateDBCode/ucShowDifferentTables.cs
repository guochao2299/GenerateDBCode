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
    public partial class ucShowDifferentTables : UserControl
    {
        public ucShowDifferentTables()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private int m_count = 0;

        public void SetTables(Dictionary<string, List<MyTableBase>> tables)
        {
            this.listView1.Items.Clear();
            m_count = 0;
            AppendTables(tables);
        }

        public void AppendTables(Dictionary<string, List<MyTableBase>> tables)
        {
            this.Cursor = Cursors.WaitCursor;

            this.listView1.SuspendLayout();

            foreach (string tableName in tables.Keys)
            {
                m_count++;
                ListViewItem lvi = new ListViewItem(m_count.ToString());
                lvi.SubItems.Add(tableName);
                lvi.SubItems.Add(tables[tableName][0].TableType);
                lvi.Tag = tables[tableName];

                this.listView1.Items.Add(lvi);
            }

            this.listView1.ResumeLayout();
            this.Cursor = Cursors.Default;
        }

        private class TableCompareResult
        {
            public List<MyColumn> commonColumns = new List<MyColumn>();
            public List<MyColumn> differentColumns = new List<MyColumn>();
            public List<MyColumn> OnlyfirstDBColumns = new List<MyColumn>();
            public List<MyColumn> OnlysecondDBColumns = new List<MyColumn>();
        }

        private void RefreshColumnListView()
        {
            this.lstColumns.Items.Clear();

            if(lstColumns.Tag==null || !(lstColumns.Tag is TableCompareResult))
            {
                return;
            }

            TableCompareResult result=(TableCompareResult)lstColumns.Tag;

            if(!cbHideCommonColumn.Checked)
            {
                foreach (MyColumn mc in result.commonColumns)
                {
                    ListViewItem lvi = new ListViewItem(mc.Name);
                    lvi.SubItems.Add(mc.Name);
                    lvi.BackColor = Color.LightGreen;
                    lvi.Tag=mc;

                    lstColumns.Items.Add(lvi);
                }
            }

            for(int i=0;i<result.differentColumns.Count;i+=2)
            {
                ListViewItem lvi = new ListViewItem(result.differentColumns[i].Name);
                lvi.SubItems.Add(result.differentColumns[i+1].Name);
                lvi.BackColor = Color.LightSkyBlue;

                List<MyColumn> columns=new List<MyColumn>();
                columns.Add(result.differentColumns[i]);
                columns.Add(result.differentColumns[i+1]);
                lvi.Tag = columns;

                lstColumns.Items.Add(lvi);
            }

            foreach (MyColumn mc in result.OnlyfirstDBColumns)
            {
                ListViewItem lvi = new ListViewItem(mc.Name);
                lvi.SubItems.Add(string.Empty);
                lvi.BackColor = Color.Tomato;
                lvi.Tag = mc;

                lstColumns.Items.Add(lvi);
            }

            foreach (MyColumn mc in result.OnlysecondDBColumns)
            {
                ListViewItem lvi = new ListViewItem(string.Empty);
                lvi.SubItems.Add(mc.Name);
                lvi.BackColor = Color.Tomato;
                lvi.Tag = mc;

                lstColumns.Items.Add(lvi);
            }
        }

        public static string CompareTables(MyTableBase firstTable, MyTableBase secondTable, bool ignoreCommonItem)
        {            
            TableCompareResult compareResult=new TableCompareResult();

            foreach (string colName in firstTable.Columns.Keys)
            {
                if (secondTable.Columns.ContainsKey(colName))
                {
                    if (firstTable.Columns[colName].PropertyEqual(secondTable.Columns[colName]))
                    {                        
                        compareResult.commonColumns.Add(firstTable.Columns[colName]);
                    }
                    else
                    {
                        compareResult.differentColumns.Add(firstTable.Columns[colName]);
                        compareResult.differentColumns.Add(secondTable.Columns[colName]);
                    }
                }
                else
                {
                    compareResult.OnlyfirstDBColumns.Add(firstTable.Columns[colName]);
                }
            }

            foreach (string colName in secondTable.Columns.Keys)
            {
                if (!firstTable.Columns.ContainsKey(colName))
                {
                    compareResult.OnlysecondDBColumns.Add(secondTable.Columns[colName]);
                }
            }

            StringBuilder sb = new StringBuilder();

            if ((!ignoreCommonItem) && (compareResult.commonColumns.Count > 0))
            {
                sb.AppendLine("\t定义相同的列：");
                foreach (MyColumn mc in compareResult.commonColumns)
                {
                    sb.AppendLine(string.Format("\t\t列{0}定义相同", mc.Name));
                }
            }

            if (compareResult.differentColumns.Count > 0)
            {
                sb.AppendLine("\t定义不同的列：");
                for (int i = 0; i < compareResult.differentColumns.Count; i++)
                {
                    sb.AppendLine("\t\t" + compareResult.differentColumns[i].ToString());
                }
            }

            if (compareResult.OnlysecondDBColumns.Count > 0)
            {
                sb.AppendLine("\t表一种缺少的列：");
                for (int i = 0; i < compareResult.OnlysecondDBColumns.Count; i++)
                {
                    sb.AppendLine("\t\t" + compareResult.OnlysecondDBColumns[i].ToString());
                }
            }

            return sb.ToString();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected)
            {
                this.dgvColumns.Rows.Clear();
                return;
            }

            if (e.ItemIndex < 0)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.dgvColumns.SuspendLayout();

            List<MyTableBase> lstTables = (List<MyTableBase>)e.Item.Tag;
            
            this.lstColumns.Items.Clear();
            
            TableCompareResult compareResult=new TableCompareResult();

            MyTableBase firstTable = lstTables[0];
            MyTableBase secondTable = lstTables[1];

            foreach (string colName in firstTable.Columns.Keys)
            {
                if (secondTable.Columns.ContainsKey(colName))
                {
                    if (firstTable.Columns[colName].PropertyEqual(secondTable.Columns[colName]))
                    {
                        compareResult.commonColumns.Add(firstTable.Columns[colName]);
                    }
                    else
                    {
                        compareResult.differentColumns.Add(firstTable.Columns[colName]);
                        compareResult.differentColumns.Add(secondTable.Columns[colName]);
                    }
                }
                else
                {
                    compareResult.OnlyfirstDBColumns.Add(firstTable.Columns[colName]);
                }
            }

            foreach (string colName in secondTable.Columns.Keys)
            {
                if (!firstTable.Columns.ContainsKey(colName))
                {
                    compareResult.OnlysecondDBColumns.Add(secondTable.Columns[colName]);
                }
            }

            this.lstColumns.Tag=compareResult;

            RefreshColumnListView();

            this.Cursor = Cursors.Default;
        }

        private void cbHideCommonColumn_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RefreshColumnListView();
            this.Cursor = Cursors.Default;
        }

        private void lstColumns_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected)
            {
                this.dgvColumns.Rows.Clear();
                return;
            }

            if (e.ItemIndex < 0)
            {
                return;
            }
            
            if (!(e.Item.Tag is MyColumn) && !(e.Item.Tag is List<MyColumn>))
            {
                return;
            }

            List<MyColumn> columns = new List<MyColumn>();

            if (e.Item.Tag is MyColumn)
            {
                columns.Add((MyColumn)e.Item.Tag);
            }
            else if (e.Item.Tag is List<MyColumn>)
            {
                columns.AddRange((List<MyColumn>)e.Item.Tag);
            }

            const int TOTAL_COUNT = 8;
            const int INDEX_INDEX = 0;
            const int NAME_INDEX = 1;
            const int TYPE_INDEX = 2;
            const int LENGTH_INDEX = 3;
            const int PRECISION_INDEX = 4;
            const int SCALE_INDEX = 5;
            const int NULLABLE_INDEX = 6;
            const int DEFAULT_INDEX = 7;

            object[] datas = new object[TOTAL_COUNT];
            int count = 1;

            foreach (MyColumn c in columns)
            {
                datas[INDEX_INDEX] = count.ToString();
                datas[NAME_INDEX] = Convert.ToString(c.Name);
                datas[TYPE_INDEX] = Convert.ToString(c.T);
                datas[LENGTH_INDEX] = Convert.ToString(c.MaxLength);
                datas[PRECISION_INDEX] = Convert.ToString(c.Precision);
                datas[SCALE_INDEX] = Convert.ToString(c.Scale);
                datas[NULLABLE_INDEX] = c.Nullable ? "true" : "false";
                datas[DEFAULT_INDEX] = c.DefaultValue;

                this.dgvColumns.Rows.Add(datas);

                if (c.IsPrimaryKey)
                {
                    this.dgvColumns.Rows[count - 1].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                count++;
            }

            this.dgvColumns.ResumeLayout();
            this.Cursor = Cursors.Default;
        }
    }
}
