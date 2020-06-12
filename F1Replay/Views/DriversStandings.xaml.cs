using F1Replay.Properties;
using F1Replay.Resources;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace F1Replay.Views
{
    public partial class DriversStandings : Page
    {
        public DriversStandings()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);

            DataTable AllData = QueryResults.Get(connection, "SELECT raceId, driverId, points, positionText, wins FROM DriverStandings");

            ResultsTable.ItemsSource = ParseHeaders(AllData).DefaultView;
        }

        private void ChangeView(object sender, RoutedEventArgs e)
        {
            string v = "2";
            string column = "wins";
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);

            DataTable rawResults = QueryResults.Get(connection, "Select * FROM DriverStandings WHERE " + column + ">" + v);
            ResultsTable.ItemsSource = ParseHeaders(rawResults).DefaultView;
        }

        // Make The Column Headers Friendlier
        private DataTable ParseHeaders(DataTable data)
        {
            foreach (DataColumn c in data.Columns)
            {
                switch (c.ColumnName)
                {
                    case "driverStandingsId":
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
                    case "points":
                        {
                            c.ColumnName = "Points";
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
                    case "wins":
                        {
                            c.ColumnName = "Wins";
                            break;
                        }
                   
                }
            }

            return data;
        }
    }
}
