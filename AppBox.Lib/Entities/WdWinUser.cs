using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.Lib.Entities
{
    public class WdWinUser
    {
        public string path;
        public string name;
        public List<WdOrg> orgs;
        public WdWinUser(string path)
        {
            orgs = new List<WdOrg>();

            this.name = path.Split('\\')[2];
            this.path = path;

            foreach (string d in FS.GetDirs(path))
            {
                if(File.Exists($@"{d}\connections.xml"))
                {
                    orgs.Add(new WdOrg(d));
                }
            }

        }
    }
}
