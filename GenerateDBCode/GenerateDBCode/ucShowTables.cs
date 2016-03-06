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
    public partial class ucShowTables : UserControl
    {
        public ucShowTables()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private int m_count = 0;

        public void SetTables<T>(IEnumerable<T> tables)
            where T:MyTableBase
        {
            this.listView1.Items.Clear();
            m_count = 0;
            AppendTables(tables);
        }

        public void AppendTables<T>(IEnumerable<T> tables)
                        where T : MyTableBase
        {
            this.Cursor = Cursors.WaitCursor;

            this.listView1.SuspendLayout();

            foreach (MyTableBase t in tables)
            {
                m_count ++;
                ListViewItem lvi = new ListViewItem(m_count.ToString());
                lvi.SubItems.Add(t.Name);
                lvi.SubItems.Add(t.TableType);
                lvi.Tag = t;

                this.listView1.Items.Add(lvi);
            }

            this.listView1.ResumeLayout();
            this.Cursor = Cursors.Default;
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

            MyTableBase mt = (MyTableBase)e.Item.Tag;
            
            this.dgvColumns.Rows.Clear();

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

            foreach (MyColumn c in mt.Columns.Values)
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
