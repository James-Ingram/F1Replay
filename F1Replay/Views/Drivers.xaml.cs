using F1Replay.Properties;
using F1Replay.Resources;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace F1Replay.Views
{
    public partial class Drivers : Page
    {
        public Drivers()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);

            DataTable AllData = QueryResults.Get(connection, "SELECT * FROM Drivers");

            ResultsTable.ItemsSource = ParseHeaders(AllData).DefaultView;
        }
        private void ChangeView(object sender, RoutedEventArgs e)
        {
            string v = "%NOR%";
            string column = "code";
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);

            DataTable rawResults = QueryResults.Get(connection, "Select * FROM DRIVERS WHERE " + column + " LIKE '" + v + "'");
            ResultsTable.ItemsSource = ParseHeaders(rawResults).DefaultView;
        }

        private DataTable ParseHeaders(DataTable data)
        {
            foreach (DataColumn c in data.Columns)
            {
                switch (c.ColumnName)
                {
                    case "driverId":
                        {
                            c.ColumnName = "Id";
                            break;
                        }
                    case "driverRef":
                        {
                            c.ColumnName = "Driver Reference";
                            break;
                        }
                    case "number":
                        {
                            c.ColumnName = "Driver Number";
                            break;
                        }
                    case "code":
                        {
                            c.ColumnName = "Code";
                            break;
                        }
                    case "forename":
                        {
                            c.ColumnName = "First Name";
                            break;
                        }
                    case "surname":
                        {
                            c.ColumnName = "Last Name";
                            break;
                        }
                    case "dob":
                        {
                            c.ColumnName = "Date Of Birth";
                            break;
                        }
                    case "nationality":
                        {
                            c.ColumnName = "Nationality";
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
