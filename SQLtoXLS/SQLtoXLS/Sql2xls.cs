using ExcelLibrary.SpreadSheet;
using System.Data;
using System.Data.SqlClient;

namespace SQLtoXLS
{
    class Sql2xls
    {
        public static string fileName { get; set; }
        public static string sqlQuery { get; set; }
        public static SqlConnection conn { get; set; }

        public Sql2xls(string f, string q, SqlConnection c) { fileName = f; sqlQuery = q; conn = c; }

        public void SaveFile()
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Workbook workbook = new Workbook();
            Worksheet sheet = new Worksheet("Лист1");

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sheet.Cells[0, i] = new Cell(dt.Columns[i].Caption);
            }

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    sheet.Cells[r + 1, c] = new Cell(dt.Rows[r].ItemArray[c].ToString());
                }
            }
            //CellFormat numberFormat = new CellFormat(CellFormatType.Number, "#.#####"); ;
            //if (dr.RowState == DataRowState.Deleted) continue;

            workbook.Worksheets.Add(sheet);
            workbook.Save(fileName);
        }
    }
}
