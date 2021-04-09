/**
 *  Document: HomeControl.xaml.cs
 *  Authors: Kristopher Hankey, 
 *           Andrew Kuo, 
 *           Calvin May, 
 *           Tom Zielinski
 *  Date: 04/09/2021
 *  Description: This is a custom control created for the MVCH System App Demo. This control is dynamically
 *               loaded onto the MainWindow.xaml, inside of the 'contentPanel' ContentPanel, depending on the position 
 *               of the User currently logged into the application.
 */

// Imports
using System.Windows;           // Default
using System.Windows.Controls;  // Default

namespace DBAS_5206_MVCH_SystemAppDemo.Controls
{
    /// <summary>
    /// Interaction logic for HomeControl.xaml
    /// </summary>
    public partial class HomeControl : UserControl
    {

        // Constructor
        public HomeControl()
        {
            InitializeComponent();

        }
    }
}
