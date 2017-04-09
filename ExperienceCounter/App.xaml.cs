using System.Windows;
using ExperienceCounter.Views;

namespace ExperienceCounter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            // Create the ViewModel and expose it using the View's DataContext
            MainView view = new MainView();
            view.DataContext = new ViewModels.MainViewModel();
            view.Show();
        }
    }
}
