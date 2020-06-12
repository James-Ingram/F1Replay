using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace F1Replay.Resources
{
    class Import
    {
        public static void Results(SqlConnection connection)
        {
        // Initialization.
            string importFilePath = "./Database/RawData/results.csv";

        // Import CSV file.
            DataTable data = CSVLibraryAK.Import(importFilePath, true);
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
            dtCloned.Columns["date"].DataType = typeof(DateTime);
            string format = "yyyy-MM-dd";

            foreach (DataRow row in data.Rows)
            { 
                DateTime date;
                DateTime.TryParseExact(row["date"].ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                row["date"] = date;
                dtCloned.ImportRow(row);
            }
            ClearTable("Races", connection);
            Add_Table_To_Database(connection, dtCloned);
            
        }
        public static void Drivers(SqlConnection connection)
        {
            // Initialization.
            bool hasHeader = true;
            string importFilePath = "./Database/RawData/drivers.csv";

            //Import Diretly From CSV
            DataTable data = CSVLibraryAK.Import(importFilePath, hasHeader);
            data.TableName = "drivers";

            //Adjust DataTypes
            DataTable dtCloned = data.Clone();
            dtCloned.Columns["driverId"].DataType = typeof(int);
            dtCloned.Columns["number"].DataType = typeof(int);
            dtCloned.Columns["dob"].DataType = typeof(DateTime);
            string format = "yyyy-MM-dd";
            foreach (DataRow row in data.Rows)
            {
                DateTime date;
                DateTime.TryParseExact(row["dob"].ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                row["dob"] = date;
                dtCloned.ImportRow(row);
            }
            ClearTable("Drivers", connection);
            Add_Table_To_Database(connection, dtCloned);

        }
        public static void Circuits(SqlConnection connection)
        {
            // Initialization.
            bool hasHeader = true;
            string importFilePath = "./Database/RawData/circuits.csv";

            //Import Diretly From CSV
            DataTable data = CSVLibraryAK.Import(importFilePath, hasHeader);
            data.TableName = "circuits";

            //Adjust DataTypes
            DataTable dtCloned = data.Clone();
            dtCloned.Columns["circuitId"].DataType = typeof(int);
            dtCloned.Columns["lat"].DataType = typeof(float);
            dtCloned.Columns["lng"].DataType = typeof(float);
            dtCloned.Columns["alt"].DataType = typeof(int);

            foreach (DataRow row in data.Rows)
            {
                dtCloned.ImportRow(row);
            }
            ClearTable("Circuits", connection);
            Add_Table_To_Database(connection, dtCloned);

        }
        public static void DriversStandings(SqlConnection connection)
        {
            // Initialization.
            bool hasHeader = true;
            string importFilePath = "./Database/RawData/driver_standings.csv";

            //Import Diretly From CSV
            DataTable data = CSVLibraryAK.Import(importFilePath, hasHeader);
            data.TableName = "DriverStandings";

            //Adjust DataTypes
            DataTable dtCloned = data.Clone();
            dtCloned.Columns["driverStandingsId"].DataType = typeof(int);
            dtCloned.Columns["points"].DataType = typeof(float);
            dtCloned.Columns["driverId"].DataType = typeof(int);
            dtCloned.Columns["raceId"].DataType = typeof(int);
            dtCloned.Columns["position"].DataType = typeof(int);
            dtCloned.Columns["wins"].DataType = typeof(int);

            foreach (DataRow row in data.Rows)
            {
                dtCloned.ImportRow(row);
            }
            ClearTable("DriverStandings", connection);
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

            bulkCopy.DestinationTableName = data.TableName;

            bulkCopy.WriteToServer(data);

            connection.Close();
        }
    }
}
