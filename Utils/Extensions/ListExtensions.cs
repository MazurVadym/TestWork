using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Extensions
{
    public static class ListExtensions
    {
        public static DataTable ToTvp<T>(this IEnumerable<T> source, string columnName = "Value")
        {
            if (source == null)
                return null;

            var table = new DataTable();
            table.Columns.Add(columnName, typeof(T));

            foreach (var tag in source)
            {
                var row = table.NewRow();

                row[columnName] = tag;

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
