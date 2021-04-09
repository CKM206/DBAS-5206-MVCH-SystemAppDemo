/**
 *  Document: AuthenticationWindow.xaml.cs
 *  Authors: Kristopher Hankey, 
 *           Andrew Kuo, 
 *           Calvin May, 
 *           Tom Zielinski
 *  Date: 04/09/2021
 *  Description: This is the Authentication Window (See App.xaml and App.xaml.cs to see how we get here). This Window
 *               allows us to authenticate users before they gain access to the MainWindow. It also provides us the info
 *               we need to dynamically load content based on login credentials.
 */
// Imports
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace DBAS_5206_MVCH_SystemAppDemo
{
    /// <summary>
    /// Interaction logic for AuthenticationWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        /// <summary>
        /// Authentication Window Constructor, Initializes all componenets 
        /// </summary>
        public AuthenticationWindow()
        {
            InitializeComponent();
            
        }

    #region Event Handlers
        /// <summary>
        /// This Event Handler executed when the Login button is Clicked.
        /// It Checks to see if the user has entered correct login information.
        /// If the information is correct it will send a dialogResult value of true
        /// which is used in App.xaml.cs to launch the MainWindow. If the Information
        /// is invalid it will set the error message on the form to visible and clear
        /// the passwordbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Declarations
            const string validID = "100745125";         // A Valid EmployeeId
            const string validID2 = "3";
            const string validPassword = "password";    // A Valid Password


            /* *** IMPORTANT NOTE ***
             * ----------------------
             * Notice that the authentication for this App is current canned/predetermined
             * login information.
             * 
             * We could allow for querying the Database for login credentials however it was
             * out of the scope for this demo. We do have the sql.client nu get package installed
             * so incorporating this functionality would be fairly staightforward, but for now
             * authentication uses canned login credentials.
             */

         
            // Check if data in the form matches the defined valid Id and Password
            //-If it does...
            if ((tbEmployeeId.Text == validID || tbEmployeeId.Text == validID2) && pbPassword.Password == validPassword)
            {
                // Hide the Login Error.
                tblkLoginError.Visibility = Visibility.Hidden;
                // Set the DialogResult to True for App.xaml.cs
                this.DialogResult = true;

                // Passes the Employee ID to the MainWindow static property so
                //-it can decide what kind of Content to load. 
                //-We could also pass this using the constructor, but since MainWindow will be called in
                //-App.xaml.cs we decided to use this as a quick workaround. Make sure to see app.xaml and app.xaml.cs to see how AuthenticationWindows & MainWindow work
                MainWindow.EmployeeId = tbEmployeeId.Text;
                // Close the Authentication window
                this.Close();
            }
            // If the Login Credentials are incorrect
            else
            {
                // Show the Login Error
                tblkLoginError.Visibility = Visibility.Visible;
                // Clear the Password Info
                pbPassword.Clear();
            }
        }

        /// <summary>
        /// This Event Handler is executed whenever the pbPassword recieves focus.
        /// It is a QOL method for clearing the error visibility whenever the
        /// password box recieves focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            // Hide the Login Error.
            tblkLoginError.Visibility = Visibility.Hidden;
        }
    #endregion
    }
}
