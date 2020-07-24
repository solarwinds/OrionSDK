using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SwqlStudio
{
    internal class DataGridExporter
    {
        /// 
        /// NOTE: This code was stolen from the SolarWinds.Orion.Common.DatabaseFunctions.DataTableToCSV
        /// 
        public void ExportAsCsv(DataGridView grid, string outputFileName)
        {
            using (StreamWriter csvStream = File.CreateText(outputFileName))
            {
                // Write the column headers
                bool isFirst = true;
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (isFirst == false)
                    {
                        csvStream.Write(",");
                    }
                    isFirst = false;
                    csvStream.Write(EscapeCsvString(col.Name));
                }
                csvStream.WriteLine();

                // Write all the data
                foreach (DataGridViewRow row in grid.Rows)
                {
                    isFirst = true;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (isFirst == false)
                        {
                            csvStream.Write(",");
                        }
                        isFirst = false;

                        object item = cell.Value;
                        if (item != null && !DBNull.Value.Equals(item))
                        {
                            if (item is DateTime)
                            {
                                csvStream.Write(EscapeCsvString(Convert.ToDateTime(item).ToString("O").Trim()));
                            }
                            else
                            {
                                csvStream.Write(EscapeCsvString(cell.FormattedValue.ToString().Trim()));
                            }
                        }
                    }
                    csvStream.WriteLine();
                }
            }

        }


        private static readonly char[] _charList = new[] { ',', ' ', '\t', '\r', '\n', '"' };
        private static string EscapeCsvString(string source)
        {
            bool needsQuotes = source.IndexOfAny(_charList) != -1;

            if (needsQuotes == false)
            {
                // nothing to do here, just return the string
                return source;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append('"');

            foreach (char c in source)
            {
                if (c == '"')
                    sb.Append('"');

                sb.Append(c);
            }

            sb.Append('"');

            return sb.ToString();
        }

    }
}