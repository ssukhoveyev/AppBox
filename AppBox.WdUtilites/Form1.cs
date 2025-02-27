using AppBox.Lib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBox.WdUtilites
{
    public partial class Form1 : Form
    {
        private WdConnection wdConnection;
        public Form1()
        {
            InitializeComponent();

            toolStripStatusLabel1.Text = "Нет подключения.";
        }

        private void подключениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectDialog connectDialog = new ConnectDialog();
            if (connectDialog.ShowDialog() == DialogResult.OK)
            {
                wdConnection = connectDialog.wdConnection;
                toolStripStatusLabel1.Text = $"Подключено {wdConnection.name}";
            }
        }

        private void старыеЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wdConnection != null)
            {
                OldOrders oldOrders = new OldOrders(wdConnection);
                oldOrders.MdiParent = this;
                oldOrders.Show();
            }
        }
    }
}
