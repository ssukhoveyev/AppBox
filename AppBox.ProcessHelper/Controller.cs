using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.ProcessHelper
{
    internal class Controller
    {
        public static void AddProcessRow(Process process, DataSet1.dtProcessDataTable dt)
        {
            DataSet1.dtProcessRow dr = (DataSet1.dtProcessRow)dt.NewRow();
            dr.id = process.Id;
            dr.name = process.ProcessName;
            dr.user = String.Empty;

            SetMemoryValue(process, dr);

            dt.AdddtProcessRow(dr);
        }

        public static void SetMemoryValue(Process process, DataSet1.dtProcessRow dr)
        {
            dr.memory = (int)(process.WorkingSet64 / 1024 / 1024);
        }

        public static string GetProcessOwner(int processId)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    return argList[0];
                }
            }

            return "NO OWNER";
        }

        public static List<Process> GetProcessWithFilter(string filter)
        {
            Process[] allProcesses = Process.GetProcesses();

            if (String.IsNullOrEmpty(filter))
                return allProcesses.ToList<Process>();
            else
                return allProcesses.ToList<Process>().FindAll(x => x.ProcessName.Contains(filter));
        }
    }
}
