using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AppBox.FTPDownloader
{
    internal static class Program
    {
        static string ftpUsername = "ftpuser";
        static string ftpPassword = "F#hRt5zPy";

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            //string ftpPath = @"ftp://bdc.kmsys.ru:53504/ECAD";
            //string pathOut = @"C:\TEMP";
            string ftpPath = args[0];
            string pathOut = args[1];

            Console.WriteLine("Arguments received.");

            List<string> files = GetFileList(ftpPath);

            Console.WriteLine("Load file list.");

            foreach (string file in files)
            {
                if (DownloadFile($"{ftpPath}/{file}", pathOut))
                    DeleteFile($"{ftpPath}/{file}");
            }

            Console.WriteLine("End.");
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

        private static bool DownloadFile(string filePath, string pathOut)
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

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void DeleteFile(string ftpPath)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
