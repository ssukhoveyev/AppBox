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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppBox.WdUtilites
{
    public partial class ConnectDialog : Form
    {
        private colWdWInUsers wdWinUsers;
        private WdWinUser wdWinUserSelected;
        private WdOrg wdOrgSelected;
        public WdConnection wdConnection;
        public ConnectDialog()
        {
            InitializeComponent();

            wdWinUsers = new colWdWInUsers();
            wdWinUsers.FillWinUsers();

            foreach(var winUser in wdWinUsers)
                listViewWinUsers.Items.Add(winUser.name);
        }

        private void listViewWinUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = listViewWinUsers.SelectedItems[0].Text;
            wdWinUserSelected = wdWinUsers.Find(x => x.name == selectedItem);

            foreach (var wdConn in wdWinUserSelected.orgs )
                listViewOrg.Items.Add(wdConn.name);
        }

        private void listViewOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrg.SelectedItems.Count > 0)
            {
                string selectedItem = listViewOrg.SelectedItems[0].Text;
                wdOrgSelected = wdWinUserSelected.orgs.Find(x => x.name == selectedItem);

                foreach (var wdConn in wdOrgSelected.connections)
                    listViewConn.Items.Add(wdConn.name);
            }
        }

        private void listViewConn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewConn.SelectedItems.Count != 0)
            {
                string selectedItem = listViewConn.SelectedItems[0].Text;
                wdConnection = wdOrgSelected.connections.Find(x => x.name == selectedItem);
                textBoxConnStr.Text = wdConnection.connectionString;
            }
        }
    }
}
