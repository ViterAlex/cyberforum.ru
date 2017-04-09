using System.ComponentModel;
using System.Windows;

namespace RunConsole.ViewModels
{
    /// <summary>
    ///     Provides common functionality for ViewModel classes
    /// </summary>
    public abstract class ViewModelBase : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handle = PropertyChanged;
            if (handle != null)
            {
                handle(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}