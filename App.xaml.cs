/**
 *  Document: App.xaml.cs
 *  Authors: Kristopher Hankey, 
 *           Andrew Kuo, 
 *           Calvin May, 
 *           Tom Zielinski
 *  Date: 04/09/2021
 *  Description: This file, along with App.xaml is how we enforce authentication and handle Application shutdowns.
                 Note that in App.xaml: Startup="Application_Startup" ShutdownMode="OnExplicitShutdown">.
                 This allows us to enforce certain rules regarding MainWindow loading, and application shutdown.
                 In Deployment, the Minimize, Maximize, and close options in the top right would be disabled. This would
                 ensure that the application is always running. Also allows us to close windows without shutting down the App. 

                 Also, the App does not startup with a particular Window,
                 It startsup using the Application_Startup Method below. The Application_Startup method launches the
                 Authentication window, and only allows the MainWindow to be loaded if the Authentication returns a Dialog
                 result of true.
 */
// Imports
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
                // Declarations
                bool closeApp = false;  // A boolean to let the App know when to shutdown

                // Loop...
                do
                {
                // Wait for the AuthenticationWindow to close...
                //-When it does check its DialogResult for True. If it
                //-returns true the user succesfully Authenticated
                    if (new AuthenticationWindow().ShowDialog() == true)
                    {
                        // Create a new MainWindow
                        //-Remember, this will return once the window is closed.
                        if (new MainWindow().ShowDialog() == false)
                            closeApp = true;
                    
                    }
                    else
                        closeApp = true;

                    // Loop Until closeApp == False
                } while (!closeApp);

            }
            finally
            {
                // Once everything has been closed, shutdown the App
                Shutdown(); // This is our Explicit shutdown 
            }
        }
    }
}
