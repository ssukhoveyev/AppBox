using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.Lib.Entities
{
    public class WdReport
    {
        static public void Save(string conStr, int idreport)
        {
            //string conStr = "uid=sa;pwd=123123;MultipleActiveResultSets=True;database=ecad_okmaster_dil;server=localhost;Connection Timeout = 60;";

            DataTable dt = new DataTable("reports");

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sqlq = $@"select report from report where idreport = {idreport}";
                SqlDataAdapter da = new SqlDataAdapter(sqlq, connection);
                da.Fill(dt);
            }

            dt.WriteXml("data.xml");
        }

        static public void Load(string conStr, int idreport)
        {
            //string conStr = "uid=sa;pwd=123123;MultipleActiveResultSets=True;database=ecad_okmaster_dil;server=localhost;Connection Timeout = 60;";

            DataTable dt = new DataTable("reports");

            dt.Columns.Add("report", typeof(byte[]));

            dt.ReadXml("data.xml");

            string queryString = $@"UPDATE report set report = @report WHERE idreport = {idreport}";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Clear();
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@report";
                parameter.SqlDbType = SqlDbType.Binary;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = dt.Rows[0]["report"];

                command.Parameters.Add(parameter);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
