using System;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using F1Replay.Properties;
using System.Windows;

namespace F1Replay.Views
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Page
    {

        public Results()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);

            DataTable AllData = GetResults(connection, "SELECT * FROM Results");

            // data.Columns.Remove("positionText");
            // data.Columns.Remove("milliseconds");
            // data.Columns.Remove("positionOrder");
            DataTable HeaderCorrectedDate = ParseHeaders(AllData);

            ResultsTable.ItemsSource = HeaderCorrectedDate.DefaultView;
        }



        private void ChangeView(object sender, RoutedEventArgs e)
        {
            string v = "18";
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);

            DataTable rawResults = GetResults(connection, "Select * FROM RESULTS WHERE raceId="+v);
            ResultsTable.ItemsSource = ParseHeaders(rawResults).DefaultView;
        }


        private DataTable GetResults(SqlConnection connection, String command)
        {            
            connection.Open();
            using SqlCommand cmd = new SqlCommand(command, connection)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            connection.Close();
            return dt;
        }        
        
        // Make The Column Headers Friendlier
        private DataTable ParseHeaders(DataTable data)
        {
            DataTable HeaderCorrectedDate;
            foreach (DataColumn c in data.Columns)
            {
                switch (c.ColumnName)
                {
                    case "resultId":
                        {
                            c.ColumnName = "Id";
                            break;
                        }
                    case "raceId":
                        {
                            c.ColumnName = "Race";
                            break;
                        }
                    case "driverId":
                        {
                            c.ColumnName = "Driver";
                            break;
                        }
                    case "ConstructorId":
                        {
                            c.ColumnName = "Constructor";
                            break;
                        }
                    case "number":
                        {
                            c.ColumnName = "Car Number";
                            break;
                        }
                    case "grid":
                        {
                            c.ColumnName = "Grid Position";
                            break;
                        }
                    case "position":
                        {
                            c.ColumnName = "Finish Position";
                            break;
                        }
                    case "positionText":
                        {
                            c.ColumnName = "Position Text";
                            break;
                        }
                    case "positionOrder":
                        {
                            c.ColumnName = "Position Order";
                            break;
                        }
                    case "points":
                        {
                            c.ColumnName = "Points";
                            break;
                        }
                    case "laps":
                        {
                            c.ColumnName = "Laps Completed";
                            break;
                        }
                    case "time":
                        {
                            c.ColumnName = "Time Taken";
                            break;
                        }
                    case "milliseconds":
                        {
                            c.ColumnName = "Milliseconds";
                            break;
                        }
                    case "fastestLap":
                        {
                            c.ColumnName = "Driver's Fastest Lap";
                            break;
                        }
                    case "rank":
                        {
                            c.ColumnName = "Fastest Lap Rank";
                            break;
                        }
                    case "fastestLapTime":
                        {
                            c.ColumnName = "Fastest Lap Time";
                            break;
                        }
                    case "fastestLapSpeed":
                        {
                            c.ColumnName = "Fastest Lap Speed";
                            break;
                        }
                        case "statusId":
                        {
                            c.ColumnName = "Classification";
                            break;
                        }

                }
            }

            HeaderCorrectedDate = data;
            return data;
        }
    }
}
