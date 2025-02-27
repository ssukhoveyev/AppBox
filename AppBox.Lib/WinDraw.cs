using System.Collections.Generic;
using System.IO;
using AppBox.Lib.Entities;

namespace AppBox.Lib
{
    public class WinDraw
    {
        static List<WdWinUser> GetWinUsers()
        {
            var userList = new List<WdWinUser>();

            foreach (var drive in FS.GetLogicalDrives())
            {
                string path = $@"{drive}Users";
                if (Directory.Exists(path))
                {
                    foreach (string userProf in FS.GetDirs(path))
                    {
                        if (Directory.Exists($@"{userProf}\AppData\Roaming\ATechnology\Atechnology.winDraw"))
                            userList.Add(new WdWinUser(userProf));
                    }
                }
            }

            return userList;
        }
    }
}
