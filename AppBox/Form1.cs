using AppBox.Backup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppBox.Backup.FileToFolder backup = new AppBox.Backup.FileToFolder();

            backup.CellPath = @"c:\TEMP\F1\";
            backup.BackupPath = @"c:\TEMP\F1Backup\";
            backup.Go();
            backup.DeleteOldBackup(new DateTime(2023, 10, 1));


        }
    }
}

