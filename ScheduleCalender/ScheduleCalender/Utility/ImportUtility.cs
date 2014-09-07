using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace ScheduleCalender
{
    public class ImportUtility
    {
        /// <summary>
        /// Converts a CSV File to DataTable
        /// </summary>
        /// <param name="filePath">String containing path to the CSV file</param>
        /// <returns>DataTable containg the imported data</returns>
        public static DataTable CSVToDataTable(string filePath, bool hasHeaders = false)
        {
            try
            {
                DataTable csvTable = new DataTable();
                StreamReader reader = new StreamReader(filePath);
                //FileStream reader = new FileStream(filePath, FileMode.Open);
                string[] columnNames;
                columnNames = reader.ReadLine().Split(',');
                for (int index = 0; index < columnNames.Length; index++)
                {
                    if (!hasHeaders)
                        csvTable.Columns.Add("Column" + index);
                    else
                        csvTable.Columns.Add(columnNames[index]);
                }
                if (!hasHeaders)
                {
                    // close and reopen
                    reader.Close();
                    reader = new StreamReader(filePath);
                }
                String[] rowContent;
                while (!reader.EndOfStream)
                {
                    rowContent = reader.ReadLine().Split(',');
                    DataRow dRow = csvTable.NewRow();
                    for (int colCount = 0; colCount < csvTable.Columns.Count; colCount++)
                    {
                        dRow[colCount] = rowContent[colCount];
                    }
                    csvTable.Rows.Add(dRow);
                }

                reader.Close();
                reader.Dispose();
                return csvTable;
            }
            catch
            {
                return null;
            }
        }

    }
}