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
    public partial class ucDBFromXmlFile : UserControl
    {
        public ucDBFromXmlFile()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "XML文件|*.xml";

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                m_filePath = ofd.FileName;
                this.textBox1.Text = ofd.FileName;
            }
        }

        private string m_filePath = string.Empty;

        public string DBXmlFilePath
        {
            get
            {
                return m_filePath;
            }
        }
    }
}
