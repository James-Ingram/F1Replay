using F1Replay.Properties;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using F1Replay.Resources;
using System.Windows;

namespace F1Replay.Views
{ 
    public partial class Circuits : Page
    {
        public Circuits()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);

            DataTable AllData = QueryResults.Get(connection, "SELECT * FROM Circuits");
            AllData.Columns.Remove("alt");
            ResultsTable.ItemsSource = ParseHeaders(AllData).DefaultView;
        }
        private void ChangeView(object sender, RoutedEventArgs e)
        {
            string v = "%australia%";
            string column = "country";
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);

            DataTable rawResults = QueryResults.Get(connection, "Select * FROM CIRCUITS WHERE " + column + " LIKE '" + v + "'");
            ResultsTable.ItemsSource = ParseHeaders(rawResults).DefaultView;
        }
        private DataTable ParseHeaders(DataTable data)
        {
            foreach (DataColumn c in data.Columns)
            {
                switch (c.ColumnName)
                {
                    case "circuitId":
                        {
                            c.ColumnName = "Id";
                            break;
                        }
                    case "circuitRef":
                        {
                            c.ColumnName = "Reference";
                            break;
                        }
                    case "name":
                        {
                            c.ColumnName = "Name";
                            break;
                        }
                    case "location":
                        {
                            c.ColumnName = "Location";
                            break;
                        }
                    case "country":
                        {
                            c.ColumnName = "Country";
                            break;
                        }
                    case "lat":
                        {
                            c.ColumnName = "Latitude";
                            break;
                        }
                    case "lng":
                        {
                            c.ColumnName = "Longitude";
                            break;
                        }
                    case "alt":
                        {
                            c.ColumnName = "Altitude";
                            break;
                        }
                    case "url":
                        {
                            c.ColumnName = "Url";
                            break;
                        }
                }
            }

            return data;
        }
    }
}
