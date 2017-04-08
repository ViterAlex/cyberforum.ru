using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

using AdjacencyMatrix.Commands;

namespace AdjacencyMatrix.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {

        #region Constructor

        public MainViewModel()
        {
            // Blank
        }

        #endregion

        private void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
