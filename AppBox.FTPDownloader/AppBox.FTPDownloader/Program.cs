using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AppBox.FTPDownloader
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //string ftpPath = @"ftp://bdc.kmsys.ru:53504/Папка1";
            //string pathOut = @"C:\TEMP";
            string ftpPath = args[0];
            string pathOut = args[1];

            List<string> files = GetFileList(ftpPath);

            foreach(string file in files)
                DownloadFile($"{ftpPath}/{file}", pathOut);
        }

        private static List<string> GetFileList(string ftpPath)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpPath);
            ftpRequest.Credentials = new NetworkCredential("ftpuser", "F#hRt5zPy");
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            List<string> directories = new List<string>();
            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = streamReader.ReadLine();
            }
            streamReader.Close();

            return directories;
        }

        private static void DownloadFile(string filePath, string pathOut)
        {
            try
            {
                if (!Directory.Exists(pathOut))
                    Directory.CreateDirectory(pathOut);

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(filePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential("ftpuser", "F#hRt5zPy");
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream fs = new FileStream(pathOut + @"/" + Path.GetFileName(filePath), FileMode.Create);

                byte[] buffer = new byte[64];
                int size = 0;

                while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, size);
                }
                fs.Close();
                response.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
