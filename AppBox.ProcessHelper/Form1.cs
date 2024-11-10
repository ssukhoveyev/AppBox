using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBox.ProcessHelper
{
    public partial class Form1 : Form
    {
        public DataSet1 ds;
        public BindingSource SBind;
        Thread updateThread;
        Thread fillUserNameThread;
        public string filterProcName;
        string appName = "Process Helper";

        public Form1()
        {
            InitializeComponent();

            this.Text = appName;

            ds = new DataSet1();
            SBind = new BindingSource();
            SBind.DataSource = ds.dtProcess;
            dataGridView1.DataSource = SBind;

            LoadProcess();

            updateThread = new Thread(UpdateProcess);
            updateThread.Start();

            fillUserNameThread = new Thread(FillUserName);
            fillUserNameThread.Start();
        }

        void LoadProcess()
        {
            foreach (Process process in Controller.GetProcessWithFilter(null))
                Controller.AddProcessRow(process, ds.dtProcess);
        }

        void UpdateProcess()
        {
            while (true)
            {
                Thread.Sleep(1000);

                List<Process> allProcesses = Controller.GetProcessWithFilter(filterProcName);

                foreach (Process process in allProcesses)
                {
                    DataSet1.dtProcessRow[] drs = (DataSet1.dtProcessRow[])ds.dtProcess.Select($"id = {process.Id}");

                    if (drs.Length == 1)
                    {
                        Action action = () => Controller.SetMemoryValue(process, drs[0]);
                        Invoke(action);
                    }
                    else if (drs.Length == 0)
                    {
                        Action action = () => Controller.AddProcessRow(process, ds.dtProcess);
                        Invoke(action);
                    }
                }
                List<int> deleted = new List<int>();

                foreach (DataSet1.dtProcessRow dr in ds.dtProcess.Rows)
                {
                    if (allProcesses.ToList().Find(x => x.Id == dr.id) == null)
                        deleted.Add(dr.id);
                }

                foreach (int i in deleted)
                {
                    Action action = () => { ds.dtProcess.Rows.Remove(ds.dtProcess.Select($"id = {i}")[0]); };
                    Invoke(action);
                }
            }
        }

        void FillUserName()
        {
            while (true)
            {
                try
                {
                    DataSet1.dtProcessRow[] drs = (DataSet1.dtProcessRow[])ds.dtProcess.Select($"isnull(user,'') = ''");
                    if (drs.Length > 0)
                    {
                        DataSet1.dtProcessRow dr = drs[0];
                        if (dr != null)
                            dr.user = Controller.GetProcessOwner(dr.id);
                    }
                }
                catch { }
            }

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateThread.Abort();
            fillUserNameThread.Abort();
        }

        private void отфильтроватьПоНазваниюПроцессаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterProcName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.Text = $"{appName} Filter:{filterProcName}";
            ds.dtProcess.Rows.Clear();
        }

        private void отфильтроватьПоПользователюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void удалитьФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterProcName = null;
            this.Text = appName;
            ds.dtProcess.Rows.Clear();
        }
    }
}
