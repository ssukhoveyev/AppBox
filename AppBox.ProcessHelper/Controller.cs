using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
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
    }
}
