using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Controls;

namespace F1Replay.Resources
{
    class Import
    {
        public static void Results(SqlConnection connection)
        {
        // Initialization.
            bool hasHeader = true;
            string importFilePath = "./Database/RawData/results.csv";
        //string exportFilePath = "C:\\export.csv";

        // Import CSV file.
            DataTable data = CSVLibraryAK.Import(importFilePath, hasHeader);
            data.TableName = "Results";

            // foreach(DataColumn header in data.Columns) Debug.Print(header.ColumnName);
            ClearTable("Results", connection);
            Add_Table_To_Database(connection, data);
        }

        private static void ClearTable(string table, SqlConnection connection)
        {
            connection.Open();
            using SqlCommand cmd = new SqlCommand("DELETE FROM " + table, connection)
            {
                CommandType = CommandType.Text
            };
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private static void Add_Table_To_Database(SqlConnection connection, DataTable data)
        {
            connection.Open();
            using SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
            foreach (DataColumn c in data.Columns)
            {
                bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
            }

            bulkCopy.DestinationTableName = data.TableName;

            bulkCopy.WriteToServer(data);

            connection.Close();
        }
    }
}
