/**
 *  Document: MainWindow.xaml.cs
 *  Authors: Kristopher Hankey, 
 *           Andrew Kuo, 
 *           Calvin May, 
 *           Tom Zielinski
 *  Date: 04/09/2021
 *  Description: This is the Main Window. This Window is only loaded once a User has been Authenticated. Most
 *               of the content in this Window is dynamically loaded based on what user has logged in. The window
 *               is split up into several areas of concern using Grid Definitions. There is a title section, an
 *               employee info section, a Menu section and a Content Section. Each of these sections load different
 *               content dependant on the User position.
 */

// Imports
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// Use our Custom Controls
using DBAS_5206_MVCH_SystemAppDemo.Controls;

namespace DBAS_5206_MVCH_SystemAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Static property for holding the ID of the authenticated User, used to fill the position variable
        public static string EmployeeId { get; set; }

        // Private position variable, to be determined by ID.
        private static string position;

        /* *** NOTE ***
         * In the future this type of information will be handled by a User Model.
         * Because this is a demo and we're using canned login info, it was easiest to
         * use simple variables within the form itself.
         * 
         * Later, the authentication could build a User Object, which could be used to hold
         * all of this information.
         * 
         */

        // Constructor
        public MainWindow()
        {
            InitializeComponent();
            ResetWindow();                  // Reset the Window!
            PopulateEmployeeInfo();         // Populate the Window with User specific Information
            PopulatePositionControls();     // Populate the Window with User specific Controls
        }

        /// <summary>
        /// This is an Event Handler. The code executes when then sign-out button is clicked.
        /// It's purpose is to close the MainWindow, and return the User back to the authentication
        /// window. To do this, before the window is closed, we set the dialogResult to true. This
        /// information is used in app.xaml.cs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            // Return a dialog result of true when signing out 
            //-(See App.xaml.cs to see how this interacts with authentication and explicit shutdowns)
            this.DialogResult = true;

            // Close the Main window
            this.Close();
        }


        /// <summary>
        /// PopulateEmployeeInfo() - This is a void method that is responsible for populating the window with 
        ///                        Employee specific information, deciding on the Employe Position, which in
        ///                        turn helps the PopulatePositionControls() method load the correct controls
        ///                        for this specific user.
        /// </summary>
        private void PopulateEmployeeInfo()
        {
            // Find out which User is logged in 
            //-(we can parse like this because we know the only valid credentials)
            if (int.Parse(EmployeeId) == 3)
            {
                // Set up the Employee Information for ID: 3
                lblEmployeeName.Content = "Xulia, Mahir";
                position = "Clerk";
                lblEmployeePosition.Content = position;
            }
            else
            {
                // Set up the Employee Information for ID: 100745125
                lblEmployeeName.Content = "Ms. Baker";
                position = "Hospital Administrator";
                lblEmployeePosition.Content = position;

            }
        }

        /// <summary>
        /// PopulatePositionControls() - This is a void method that is responsible for loading the
        ///                            user specific control options/menu. Depending on which Position
        ///                            the User holds we'll load a different set of controls.
        /// </summary>
        private void PopulatePositionControls()
        {
            // If the Employee is a Clerk....
            if (position == "Clerk")
            {
                // Load the Clerk Controls
                controlPanel.Children.Add(new ClerkControls(contentPanel));
            }
            // If the Employee is a Hospital Administrator
            else if (position == "Hospital Administrator")
            {
                // Load the Hospital Administrator Controls
                controlPanel.Children.Add(new COSControls(contentPanel));
            }
        }

        /// <summary>
        /// ResetWindow() - A Void method that ensures that the MainWindow is ready to populate user specific
        ///               content by emptying the controlPanel section, and the contentPanel section of the window.
        ///               It also sets the Home Control as the initial content.
        /// </summary>
        private void ResetWindow()
        {
            // Set the ContentPanel's Content to the Control
            Control homeControl = new HomeControl();
            this.contentPanel.Content = homeControl;

            // Clear the Controls
            this.controlPanel.Children.Clear();
        }

    }
}
