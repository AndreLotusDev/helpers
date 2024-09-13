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
    }
}
