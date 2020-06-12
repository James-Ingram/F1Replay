using System;
using System.Windows;
using System.Windows.Input;


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
            DynamicContent.Navigate(new Uri("Views/DriversStandings.xaml", UriKind.Relative));
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
