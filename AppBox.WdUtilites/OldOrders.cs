using AppBox.Lib;
using AppBox.Lib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBox.WdUtilites
{
    public partial class OldOrders : Form
    {
        private WdConnection wdConnection;
        private List<DocOper> docOpers;
        private List<DocState> docState;
        public OldOrders(WdConnection wdConnection)
        {
            InitializeComponent();
            this.Text = wdConnection.name;

            this.wdConnection = wdConnection;

            docOpers = new List<DocOper>();
            string sqlq = "select d.iddocoper,d.name from orders o join docoper d on o.iddocoper = d.iddocoper group by d.iddocoper,d.name";
            foreach (DataRow dr in MsSQLHelper.GetDataTable(sqlq, wdConnection.connectionString).Rows)
            {
                docOpers.Add(new DocOper(dr));
                cBoxDockOper.Items.Add(dr["name"].ToString());
            }
            cBoxDockOper.SelectedIndex = 0;

            docState = new List<DocState>();
            sqlq = "select d.iddocstate,d.name from orders o join docstate d on o.iddocstate = d.iddocstate group by d.iddocstate,d.name";
            foreach (DataRow dr in MsSQLHelper.GetDataTable(sqlq, wdConnection.connectionString).Rows)
            {
                docState.Add(new DocState(dr));
                cBoxDockState.Items.Add(dr["name"].ToString());
            }
            cBoxDockState.SelectedIndex = 0;

            DateTime dateOldOrder = new DateTime(2010,1,1);

            string sql = "SELECT min(dtdoc) FROM orders";
            using (SqlConnection conn = new SqlConnection(wdConnection.connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    dateOldOrder = (DateTime)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            dtStart.Value = dateOldOrder;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listViewOrders.Items.Clear();

            using (SqlConnection connection = new SqlConnection(wdConnection.connectionString))
            {
                string dtFilter = $"o.dtdoc BETWEEN '{dtStart.Value.ToString("yyyyMMdd")}' AND '{dtStop.Value.ToString("yyyyMMdd")}'";

                string operFilter = $@"o.iddocoper = {docOpers.Find(x => x.name == cBoxDockOper.Text).id}";
                string statFilter = $@"o.iddocstate = {docState.Find(x => x.name == cBoxDockState.Text).id}";

                string sqlq = @"
                    SELECT 
	                    idorder
	                    ,o.name
	                    ,c.name as customer
	                    ,o.dtdoc as o_date
                    FROM orders o
                    LEFT JOIN customer c ON c.idcustomer = o.idcustomer
                    ";

                sqlq += $" WHERE {dtFilter} AND {operFilter} AND {statFilter}";

                SqlDataAdapter da = new SqlDataAdapter(sqlq, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = row[0].ToString();
                    listViewItem.SubItems.AddRange(new string[] { row[1].ToString(), row[2].ToString(), row[3].ToString() });
                    listViewOrders.Items.Add(listViewItem);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            label1.Text = $"0 из {listViewOrders.Items.Count.ToString()}";

            int count = 1;
            progressBar1.Maximum = listViewOrders.Items.Count;

            List<int> list = new List<int>();
            foreach (ListViewItem item in listViewOrders.Items)
                list.Add(Convert.ToInt32(item.Text));

            var t = new Task(() => {
                foreach (int idorder in list)
                {
                    WindrawDocOrder windrawDocOrder = new WindrawDocOrder();
                    windrawDocOrder.id = idorder;

                    if(checkBoxRemove.Checked)
                        windrawDocOrder.RemoveDoc(wdConnection.connectionString);
                    else if (checkBoxModelPic.Checked)
                        windrawDocOrder.ClearModelPic(wdConnection.connectionString);

                    Action action = () => { label1.Text = $"{count} из {listViewOrders.Items.Count.ToString()}"; progressBar1.Value = count; };
                    Invoke(action);

                    count++;
                }
            });
            t.Start();
            //t.Wait();
        }
    }
}
