using AppBox.CopyFileApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppBox.CopyFileApp
{
    public partial class Form1 : Form
    {
        private bool needClose;
        public Form1()
        {
            InitializeComponent();

            needClose = false;

            textBoxSourceDir.Text = Settings.Default.SourcePath;
            textBoxTargetlDir.Text = Settings.Default.TargetPath;
            checkBoxAutoStart.Checked = Settings.Default.NeedAutoStart;

            timer1.Interval = GetInterval(Settings.Default.Interval);
            comboBoxInterval.Text = Settings.Default.Interval;

            checkBoxDelFile.Checked = Settings.Default.DelSourceFile;

            if (Settings.Default.NeedAutoStart)
                timer1.Start();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {

            notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
        }


        private void butSourceDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSourceDir.Text = folderBrowserDialog.SelectedPath;
                Settings.Default.SourcePath = folderBrowserDialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!needClose)
                e.Cancel = true;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            CopyFile();
        }

        private void butTargetDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxTargetlDir.Text = folderBrowserDialog.SelectedPath;
                Settings.Default.TargetPath = folderBrowserDialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            needClose = true;
            this.Close();
        }

        private void checkBoxAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAutoStart.Checked)
                Settings.Default.NeedAutoStart = true;
            else
                Settings.Default.NeedAutoStart = false;
            
            Settings.Default.Save();
        }

        private void CopyFile()
        {
            string[] files = Directory.GetFiles(Settings.Default.SourcePath, "*.*");
            List<string> filesList = files.OfType<string>().ToList();

            foreach (string file in files)
            {
                string targetFile = $@"{Settings.Default.TargetPath}\{Path.GetFileName(file)}";
                if (File.Exists(targetFile))
                {
                    if (IsNewFileVersion(file, targetFile))
                    {
                        File.Delete(targetFile);
                        File.Copy(file, targetFile);

                        if(checkBoxDelFile.Checked)
                            File.Delete(file);

                        textBoxLog.Text += DateTime.Now.ToString() + " " + Path.GetFileName(targetFile) + Environment.NewLine;
                    }
                }
                else
                {
                    File.Copy(file, targetFile);

                    if (checkBoxDelFile.Checked)
                        File.Delete(file);

                    textBoxLog.Text += DateTime.Now.ToString() + " " + Path.GetFileName(targetFile) + Environment.NewLine;
                }
            }
        }

        private bool IsNewFileVersion(string file, string fileBackup)
        {
            DateTime modificationFile = File.GetLastWriteTime(file);
            DateTime modificationFileBackup = File.GetLastWriteTime(fileBackup);

            if (modificationFile > modificationFileBackup)
                return true;
            return false;
        }

        private int GetInterval(string s)
        {
            int res;

            switch(s)
            {
                case "5 сек": res = 5000; break;
                case "15 сек": res = 15000; break;
                case "30 сек": res = 30000; break;
                case "1 мин": res = 1000 * 60; break;
                case "5 мин": res = 1000 * 60 * 5; break;
                case "15 мин": res = 1000 * 60 * 15; break;
                default: res = 5000; break;
            }
            return res;
        }

        private void comboBoxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.Interval = comboBoxInterval.Text;
            Settings.Default.Save();
            timer1.Interval = GetInterval(Settings.Default.Interval);
        }

        private void checkBoxDelFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDelFile.Checked)
            {
                Settings.Default.DelSourceFile = true;
            }
            else
            {
                Settings.Default.DelSourceFile = false;
            }

            Settings.Default.Save();
        }
    }
}
