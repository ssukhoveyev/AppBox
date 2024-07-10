using AppBox.JKOMachines.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TestGraphicsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Beem beem = new Beem();
            beem.Lenght = 1000;

            //beem.operations = new List<Operation>();
            beem.operations.Add(new Operation() { CoordX = 500, code = "100", name = "Test"});

            pictureBox1.Image = beem.GetBitmap(600,200);
        }
    }
}
