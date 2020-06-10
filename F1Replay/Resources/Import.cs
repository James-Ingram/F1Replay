using System.Data;
using System.Data.SqlClient;

namespace F1Replay.Resources
{
    class Import
    {
        public static void Results(SqlConnection connection)
        {
        // Initialization.
            bool hasHeader = true;
            string importFilePath = "./Database/RawData/results.csv";

        // Import CSV file.
            DataTable data = CSVLibraryAK.Import(importFilePath, hasHeader);
            data.TableName = "Results";

            //Adjust DataTypes
            DataTable dtCloned = data.Clone();
            dtCloned.Columns["raceId"].DataType = typeof(int);
            dtCloned.Columns["resultId"].DataType = typeof(int);
            dtCloned.Columns["constructorId"].DataType = typeof(int);
            dtCloned.Columns["number"].DataType = typeof(int);
            dtCloned.Columns["grid"].DataType = typeof(int);
            dtCloned.Columns["position"].DataType = typeof(int);
            dtCloned.Columns["positionOrder"].DataType = typeof(int);
            dtCloned.Columns["points"].DataType = typeof(float);
            dtCloned.Columns["laps"].DataType = typeof(int);
            dtCloned.Columns["milliseconds"].DataType = typeof(int);
            dtCloned.Columns["fastestLap"].DataType = typeof(int);
            dtCloned.Columns["rank"].DataType = typeof(int);
            dtCloned.Columns["statusId"].DataType = typeof(int);
            foreach (DataRow row in data.Rows)
            {
                dtCloned.ImportRow(row);
            }
            ClearTable("Results", connection);
            Add_Table_To_Database(connection, dtCloned);
        }

        public static void Races(SqlConnection connection)
        {
            // Initialization.
            bool hasHeader = true;
            string importFilePath = "./Database/RawData/races.csv";

            //Import Diretly From CSV
            DataTable data = CSVLibraryAK.Import(importFilePath, hasHeader);
            data.TableName = "races";

            //Adjust DataTypes
            DataTable dtCloned = data.Clone();
            dtCloned.Columns["raceId"].DataType = typeof(int);
            dtCloned.Columns["round"].DataType = typeof(int);
            dtCloned.Columns["circuitId"].DataType = typeof(int);
            foreach (DataRow row in data.Rows)
            {
                dtCloned.ImportRow(row);
            }
            ClearTable("Races", connection);
            Add_Table_To_Database(connection, dtCloned);
            
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
           //  foreach (DataColumn c in data.Columns)
           //  {
           //     bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
           // }

            bulkCopy.DestinationTableName = data.TableName;

            bulkCopy.WriteToServer(data);

            connection.Close();
        }
    }
}
