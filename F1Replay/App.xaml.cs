using System.Data.SqlClient;
using System.Windows;
using F1Replay.Properties;
using F1Replay.Resources;

namespace F1Replay
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            SqlConnection connection = new SqlConnection(Settings.Default.connection_String);
            Import.Results(connection);
            Import.Races(connection);
        }

    }
}
