using AppBox.Lib.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.Lib
{
    public class MsSQLHelper
    {
        public static DataTable GetDataTable(string sqlq, string connectionString)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlq, connection);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
