﻿using F1Replay.Properties;
using F1Replay.Resources;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Views
{
    public partial class Races : Page
    {
        public Races()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);

            DataTable allData = QueryResults.Get(connection, "SELECT * FROM Races");

            ResultsTable.ItemsSource = ParseHeaders(allData).DefaultView;
        }


        private void ChangeView(object sender, RoutedEventArgs e)
        {
            string v = "%australian%";
            string column = "name";
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);

            DataTable rawResults = QueryResults.Get(connection, "Select * FROM RACES WHERE " + column + " LIKE '" + v+"'");
            ResultsTable.ItemsSource = ParseHeaders(rawResults).DefaultView;
        }

        private DataTable ParseHeaders(DataTable data)
        {
            foreach (DataColumn c in data.Columns)
            {
                switch (c.ColumnName)
                {
                    case "raceId":
                        {
                            c.ColumnName = "Race";
                            break;
                        }
                    case "year":
                        {
                            c.ColumnName = "Year";
                            break;
                        }
                    case "round":
                        {
                            c.ColumnName = "Round";
                            break;
                        }
                    case "circuitId":
                        {
                            c.ColumnName = "Circuit";
                            break;
                        }
                    case "name":
                        {
                            c.ColumnName = "Grand Prix Name";
                            break;
                        }
                    case "date":
                        {
                            c.ColumnName = "Date";
                            break;
                        }
                    case "time":
                        {
                            c.ColumnName = "Time";
                            break;
                        }
                    case "url":
                        {
                            c.ColumnName = "Wiki Page Link";
                            break;
                        }
                }
            }

            return data;
        }

    }
}
