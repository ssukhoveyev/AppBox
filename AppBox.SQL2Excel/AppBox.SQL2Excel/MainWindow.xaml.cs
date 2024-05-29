using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Diagnostics;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using AppBox.SQL2Excel.Properties;

namespace AppBox.SQL2Excel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        public static DataTable dt;
        public static string connectionString;

        public MainWindow()
        {
            InitializeComponent();
            textBoxQuery.Text = Settings.Default.Query;
            connectionString = $"Server= localhost; Database= {Settings.Default.dbName}; Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT name FROM sys.databases", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    while (reader.Read())
                        CbDBSelect.Items.Add(reader.GetValue(0).ToString());

                reader.Close();
            }

            if(CbDBSelect.Items.Contains(Settings.Default.dbName))
                CbDBSelect.SelectedIndex = CbDBSelect.Items.IndexOf(Settings.Default.dbName);
            else
                CbDBSelect.SelectedIndex = 0;
        }

        private async void textBoxQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                string s = textBoxQuery.Text;
                dt = await Task.Run(() => ExecQuery(s));

                Settings.Default.Query = s;
                Settings.Default.Save();
            }
        }

        private DataTable ExecQuery(string sqlq)
        {
            

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqlq, connection);
                da.Fill(dt);
            }

            Dispatcher.BeginInvoke((Action)(() => this.dataGridResult.ItemsSource = dt.AsDataView()));

            return dt;
        }

        private void dataGridResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F6)
                SaveToExcel();
        }

        private void CbDBSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Settings.Default.dbName = CbDBSelect.SelectedValue.ToString();
            Settings.Default.Save();
            connectionString = $"Server= localhost; Database= {Settings.Default.dbName}; Integrated Security=True;";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = textBoxQuery.Text;
            dt = await Task.Run(() => ExecQuery(s));

            Settings.Default.Query = s;
            Settings.Default.Save();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveToExcel();
        }

        private void SaveToExcel()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".text";
            dlg.Filter = "Excel documents (.xlsx)|*.xlsx";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;

                #region Сохранение в XLS

                MSExcel.Application ex = new MSExcel.Application();
                ex.Visible = false;
                ex.SheetsInNewWorkbook = 1;
                MSExcel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
                ex.DisplayAlerts = false;
                MSExcel.Worksheet sheet = (MSExcel.Worksheet)ex.Worksheets.get_Item(1);
                sheet.Name = "Материалы";
                sheet.StandardWidth = 10;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                }

                for (int ri = 0; ri < dt.Rows.Count; ri++)
                {
                    for (int ci = 0; ci < dt.Columns.Count; ci++)
                    {
                        sheet.Cells[ri + 2, ci + 1] = dt.Rows[ri][ci].ToString();
                    }
                }

                ////Ширина колонки
                //MSExcel.Range rangeС2 = sheet.Range[sheet.Cells[1, 2], sheet.Cells[1, 2]];
                //rangeС2.ColumnWidth = 15;
                ////sheet.Columns[2].ColumnWidth = 15;

                //MSExcel.Range rangeС3 = sheet.Range[sheet.Cells[1, 3], sheet.Cells[1, 3]];
                //rangeС3.ColumnWidth = 50;
                ////sheet.Columns[3].ColumnWidth = 50;

                //MSExcel.Range rangeС4 = sheet.Range[sheet.Cells[1, 4], sheet.Cells[1, 4]];
                //rangeС4.ColumnWidth = 20;
                ////sheet.Columns[4].ColumnWidth = 20;

                //Захватываем диапазон ячеек
                MSExcel.Range rangeHeader = sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, dt.Columns.Count]];
                rangeHeader.Cells.Font.Name = "Tahoma";
                rangeHeader.Cells.Font.Size = 10;
                rangeHeader.Cells.Font.Bold = true;

                rangeHeader.Borders.get_Item(MSExcel.XlBordersIndex.xlEdgeBottom).LineStyle = MSExcel.XlLineStyle.xlContinuous;
                rangeHeader.Borders.get_Item(MSExcel.XlBordersIndex.xlEdgeRight).LineStyle = MSExcel.XlLineStyle.xlContinuous;
                rangeHeader.Borders.get_Item(MSExcel.XlBordersIndex.xlInsideHorizontal).LineStyle = MSExcel.XlLineStyle.xlContinuous;
                rangeHeader.Borders.get_Item(MSExcel.XlBordersIndex.xlInsideVertical).LineStyle = MSExcel.XlLineStyle.xlContinuous;
                rangeHeader.Borders.get_Item(MSExcel.XlBordersIndex.xlEdgeTop).LineStyle = MSExcel.XlLineStyle.xlContinuous;
                rangeHeader.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0xFF, 0xFF, 0xCC));

                MSExcel.Range range = sheet.Range[sheet.Cells[2, 1], sheet.Cells[dt.Rows.Count + 1, dt.Columns.Count]];
                range.Cells.Font.Name = "Tahoma";
                range.Cells.Font.Size = 10;

                range.Borders.get_Item(MSExcel.XlBordersIndex.xlEdgeBottom).LineStyle = MSExcel.XlLineStyle.xlContinuous;
                range.Borders.get_Item(MSExcel.XlBordersIndex.xlEdgeRight).LineStyle = MSExcel.XlLineStyle.xlContinuous;
                range.Borders.get_Item(MSExcel.XlBordersIndex.xlInsideHorizontal).LineStyle = MSExcel.XlLineStyle.xlContinuous;
                range.Borders.get_Item(MSExcel.XlBordersIndex.xlInsideVertical).LineStyle = MSExcel.XlLineStyle.xlContinuous;
                range.Borders.get_Item(MSExcel.XlBordersIndex.xlEdgeTop).LineStyle = MSExcel.XlLineStyle.xlContinuous;

                ex.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, MSExcel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                ex.Quit();

                #endregion
            }
        }
    }
}
