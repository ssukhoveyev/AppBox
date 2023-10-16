using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.Backup
{
    public class FileToFolder
    {
        private string _cellFolder;
        public string CellPath
        {
            get
            {
                return _cellFolder;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _cellFolder = value;
                else
                    throw new ArgumentException("Пустой путь к исходной папке.");
            }
        }

        private string _backupPath;
        public string BackupPath
        {
            get
            {
                return _backupPath;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _backupPath = value;
                else
                    throw new ArgumentException("Пустой путь к папке резервной копии.");
            }
        }

        public void Go()
        {
            List<string> files = GetFiles();
            foreach(string file in files)
            {
                string backupFile = _backupPath + Path.GetFileName(file);
                if (File.Exists(backupFile))
                {
                    if(IsNewFileVersion(file,backupFile))
                    {
                        File.Delete(backupFile);
                        File.Copy(file, backupFile);
                    }
                }
                else
                {
                    File.Copy(file, backupFile);
                }
            }
        }

        public void DeleteOldBackup(DateTime dateTime)
        {
            foreach (string file in Directory.GetFiles(_backupPath, "*.*"))
            {
                if(File.GetLastWriteTime(file) < dateTime)
                {
                    File.Delete(file);
                }
            }
        }

        private List<string> GetFiles()
        {
            string[] files = Directory.GetFiles(_cellFolder, "*.*");
            List<string> filesList = files.OfType<string>().ToList();
            return filesList;
        }

        private bool IsNewFileVersion(string file, string fileBackup)
        {
            DateTime modificationFile = File.GetLastWriteTime(file);
            DateTime modificationFileBackup = File.GetLastWriteTime(fileBackup);

            if (modificationFile > modificationFileBackup)
                return true;
            return false;
        }
    }
}