using System.Data.SqlClient;

namespace SQLtoXLS
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbUserName = "sa";
            string dbUserPass = "WinFlex2016";
            string dbSevName = @"192.168.0.201";
            string dbName = "ecad_bosfor444";
            int timeOut = 10;
            SqlConnection conn = new SqlConnection($"uid={dbUserName};pwd={dbUserPass};MultipleActiveResultSets=True;database={dbName};server={dbSevName};Connection Timeout = {timeOut};");

            Sql2xls xl = new Sql2xls("1.xls", @"SELECT * FROM people", conn);
            xl.SaveFile();
        }
    }
}
