using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.Lib.Entities
{
    public class WindrawDocOrder : WindrawDoc
    {
        public void ClearModelPic(string connString)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter($@"SELECT idmodelpic FROM modelpic WHERE idorder = {id}", connection);
                da.Fill(dt);
            }

            foreach (DataRow dr in dt.Rows)
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand($@"delete from modelpic where idmodelpic = {dr["idmodelpic"]}", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
        public void ClearModelCalc(string connString)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"SELECT idmodelcalc FROM modelcalc WHERE idorder = {id}", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SqlCommand commandDelete = new SqlCommand($@"delete from modelcalc where idmodelcalc = {reader.GetValue(0)}", connection);
                        commandDelete.Connection.Open();
                        commandDelete.ExecuteNonQuery();
                    }
                }
                reader.Close();
            }
        }

        public void RemoveDoc(string connString)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                string sql = $@"exec dbo.pg_remove_order {id}";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandTimeout = 6000;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
