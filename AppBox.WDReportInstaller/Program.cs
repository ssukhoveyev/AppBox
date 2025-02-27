using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppBox.Lib;
using AppBox.Lib.Entities;

namespace AppBox.WDReportInstaller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start");

                colWdWInUsers wdWinUsers = new colWdWInUsers();
                wdWinUsers.FillWinUsers();

                string cs = wdWinUsers[0].orgs.Find(x => x.name == "ООО Окна Мастер").connections[0].connectionString;

                Console.WriteLine(cs);

                //WdReport.Save(cs, 583);
                //WdReport.Load(cs, 583);

                Console.WriteLine("End.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }

        static void WriteList(List<string> list)
        {
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
