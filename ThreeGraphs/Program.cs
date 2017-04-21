using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace ThreeGraphs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");
            Application.Run(new MainForm());
        }
    }
}
