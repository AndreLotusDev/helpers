using System.Data;

namespace WorldCheckTester.Helper
{
    public class DataTableHelper
    {
        public static DataTable ToDataTable(IEnumerable<dynamic> items)
        {
            var dataTable = new DataTable();

            if (items == null || !items.Any())
            {
                return dataTable;
            }

            var firstItem = items.First();
            foreach (var property in ((IDictionary<string, object>)firstItem).Keys)
            {
                dataTable.Columns.Add(property);
            }

            foreach (var item in items)
            {
                var row = dataTable.NewRow();
                foreach (var property in (IDictionary<string, object>)item)
                {
                    row[property.Key] = property.Value ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static void ExtractExcel(DataTable dataTable)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        string fileName = "excel_temp.xlsx";
        string filePath = Path.Combine(desktopPath, fileName);

        IWorkbook workbook = new XSSFWorkbook();

        ISheet sheet = workbook.CreateSheet(dataTable.TableName ?? "sheet_temp");

        IRow headerRow = sheet.CreateRow(0);
        for (int i = 0;
             i < dataTable.Columns.Count;
             i++)
        {
            ICell cell = headerRow.CreateCell(i);
            cell.SetCellValue(dataTable.Columns[i].ColumnName);
        }

        for (int i = 0;
             i < dataTable.Rows.Count;
             i++)
        {
            DataRow dataRow = dataTable.Rows[i];
            IRow excelRow = sheet.CreateRow(i + 1);

            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                ICell cell = excelRow.CreateCell(j);

                object value = dataRow[j];
                if (value == DBNull.Value || value == null)
                {
                    cell.SetCellValue(string.Empty);
                }
                else
                {
                    switch (Type.GetTypeCode(value.GetType()))
                    {
                        case TypeCode.String:
                            cell.SetCellValue((string)value);
                            break;
                        case TypeCode.DateTime:
                            cell.SetCellValue(((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"));
                            break;
                        case TypeCode.Boolean:
                            cell.SetCellValue((bool)value);
                            break;
                        case TypeCode.Int32:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                        case TypeCode.Single:
                            cell.SetCellValue(Convert.ToDouble(value));
                            break;
                        default:
                            cell.SetCellValue(value.ToString());
                            break;
                    }
                }
            }
        }

        for (int i = 0; i < dataTable.Columns.Count; i++)
        {
            sheet.AutoSizeColumn(i);
        }

        using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            workbook.Write(fs);
        }

        Console.WriteLine($"Excel file saved to: {filePath}");
    }
    }
}
