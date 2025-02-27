using System.Collections.Generic;
using System.IO;

namespace AppBox.Lib.Entities
{
    public class colWdWInUsers : List<WdWinUser>
    {
        public void FillWinUsers()
        {
            foreach (var drive in FS.GetLogicalDrives())
            {
                string path = $@"{drive}Users";
                if (Directory.Exists(path))
                {
                    foreach (string userProf in FS.GetDirs(path))
                    {
                        if (Directory.Exists($@"{userProf}\AppData\Roaming\ATechnology\Atechnology.winDraw"))
                            Add(new WdWinUser($@"{userProf}\AppData\Roaming\ATechnology\Atechnology.winDraw"));
                    }
                }
            }
        }
    }
}
