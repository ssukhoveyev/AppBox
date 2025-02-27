using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.Lib.Entities
{
    public class WdOrg
    {
        public string name;
        public string paht;
        public List<WdConnection> connections;
        public WdOrg(string path)
        {
            name = new DirectoryInfo(path).Name;

            connections = new List<WdConnection>();

            DataTable dt = new DataTable("connection");
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("comment", typeof(string));
            dt.Columns.Add("host", typeof(string));
            dt.Columns.Add("base", typeof(string));
            dt.Columns.Add("typ", typeof(int));
            dt.Columns.Add("user", typeof(string));
            dt.Columns.Add("password", typeof(byte[]));
            dt.Columns.Add("selected", typeof(int));
            dt.Columns.Add("server", typeof(string));
            dt.Columns.Add("ImageIndex", typeof(int));

            dt.ReadXml($@"{path}\connections.xml");

            foreach(DataRow dr in dt.Rows)
            {
                connections.Add(new WdConnection(dr));
            }
        }
    }
}
