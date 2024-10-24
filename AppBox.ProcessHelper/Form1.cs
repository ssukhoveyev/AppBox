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
        public Form1()
        {
            InitializeComponent();

            ds = new DataSet1();
            SBind = new BindingSource();
            SBind.DataSource = ds.dtProcess;
            dataGridView1.DataSource = SBind;

            LoadProcess();

            updateThread = new Thread(UpdateProcess);
            updateThread.Start();
        }

        void LoadProcess()
        {
            Process[] allProcesses = Process.GetProcesses();

            foreach (Process process in allProcesses)
                Controller.AddProcessRow(process, ds.dtProcess);
        }

        void UpdateProcess()
        {
            while (true)
            {
                Thread.Sleep(1000);

                Process[] allProcesses = Process.GetProcesses();

                foreach (Process process in allProcesses)
                {
                    DataSet1.dtProcessRow[] drs = (DataSet1.dtProcessRow[])ds.dtProcess.Select($"id = {process.Id}");

                    if (drs.Length == 1)
                    {
                        DataSet1.dtProcessRow dr = drs[0];
                        Action action = () => Controller.SetMemoryValue(process, dr);
                        Invoke(action);
                    }
                    else if (drs.Length == 0)
                    {
                        Action action = () => {
                            Controller.AddProcessRow(process, ds.dtProcess);
                        };
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateThread.Abort();
        }

        private void отфильтроватьПоНазваниюПроцессаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отфильтроватьПоПользователюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void удалитьФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
