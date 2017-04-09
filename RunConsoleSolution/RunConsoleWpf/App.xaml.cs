using System.Windows;
using RunConsole.ViewModels;
using RunConsole.Views;

namespace RunConsole
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            // Create the ViewModel and expose it using the View's DataContext
            MainView view = new MainView {DataContext = new MainViewModel()};
            view.Show();
        }
    }
}