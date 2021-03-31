using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DBAS_5206_MVCH_SystemAppDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// This Event Handler will be called upon Startup.
        /// It Creates a new AuthenticationWindow to ensure that
        /// Users log in before showing the MainWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                // Wait for the AuthenticationWindow to close...
                //-When it does check its DialogResult for True. If it
                //-returns true the user succesfully Authenticated
                if (new AuthenticationWindow().ShowDialog() == true)
                {
                    // Create a new MainWindow
                    //-Remember, this will return once the window is closed.
                    new MainWindow().ShowDialog();
                }

            }
            finally
            {
                // Once everything has been closed, shutdown the App
                Shutdown();
            }
        }
    }
}
