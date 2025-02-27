using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.Lib
{
    public class FS
    {
        /// <summary>
        /// Список всех папок
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> GetDirs(string path)
        {
            return GetDirsFromMask(path, "*");
        }
        /// <summary>
        /// Список папок с указанной маской
        /// </summary>
        /// <param name="path"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static List<string> GetDirsFromMask(string path, string mask)
        {
            List<string> res = new List<string>();
            //получть список каталогов на букву D
            string[] dirs = Directory.GetDirectories(path, mask);

            foreach (string d in dirs)
                res.Add(d);

            return res;
        }
        /// <summary>
        /// Список логических дисков
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<string> GetLogicalDrives()
        {
            List<string> res = new List<string>();

            try
            {
                string[] drives = Directory.GetLogicalDrives();
                foreach (string driver in drives)
                    res.Add(driver);
            }
            catch (System.IO.IOException)
            {
                throw new Exception("Ошибка (I/O error)");
            }
            catch (System.Security.SecurityException)
            {
                throw new Exception("Недостаточно прав для выполнения операции");
            }

            return res;
        }
    }
}
