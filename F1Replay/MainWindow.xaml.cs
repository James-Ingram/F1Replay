using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace F1Replay
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StateChanged += MainWindowStateChangeRaised;
        }

        // Navigation
        private void HomePage(object sender, RoutedEventArgs e)
        {
            DynamicContent.Navigate(new Uri("Views/Races.xaml", UriKind.Relative));
        }
        private void RacesPage(object sender, RoutedEventArgs e)
        {
            DynamicContent.Navigate(new Uri("Views/Races.xaml", UriKind.Relative));
        }
        private void ResultsPage(object sender, RoutedEventArgs e)
        {
            DynamicContent.Navigate(new Uri("Views/Results.xaml", UriKind.Relative));
        }
        private void CircuitsPage(object sender, RoutedEventArgs e)
        {
            DynamicContent.Navigate(new Uri("Views/Circuits.xaml", UriKind.Relative));
        }
        private void DriversPage(object sender, RoutedEventArgs e)
        {
            DynamicContent.Navigate(new Uri("Views/Drivers.xaml", UriKind.Relative));
        }
        private void DriverStandingsPage(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Driver Standings Page Switch, Eventually...", "This is a WIP Feature");
        }


        // Window Commands
        // Can execute
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Minimize
        private void CommandBinding_Executed_Minimize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        // Maximize
        private void CommandBinding_Executed_Maximize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        // Restore
        private void CommandBinding_Executed_Restore(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        // Close
        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        // State change
        private void MainWindowStateChangeRaised(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {

                RestoreButton.Visibility = Visibility.Visible;
                MaximizeButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                RestoreButton.Visibility = Visibility.Collapsed;
                MaximizeButton.Visibility = Visibility.Visible;
            }
        }
    }
}
