using AppBox.ECADMachines.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Resources.ResXFileRef;
using static System.Windows.Forms.ListViewItem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EcadViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TreeNode treeNode = GenNode("t1", "1111");
            
            treeNode.Nodes.Add(GenNode("t2", "222"));

            treeView1.Nodes.Add(GenNode("t1", "1111"));
            treeView1.Nodes.Add(treeNode);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileContent = string.Empty;
            string filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            EcadConverter ecadConverter = new EcadConverter();
            ecadConverter.ConvertToCadData(fileContent);

        }

        public TreeNode GenNode(string tag, string text)
        {
            TreeNode treeNode = new TreeNode();
            treeNode.Text = text;
            treeNode.Tag = tag;

            return treeNode;
        }

        private void тестФункцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "W4302/00/16730/00000";

            string[]opSplit = s.Split('/');

            string code = opSplit[0].Trim('W');
            double CoordX = double.Parse(opSplit[2])/10;

        }
    }
}
