/**
 *  Document: HomeControl.xaml.cs
 *  Authors: Kristopher Hankey, 
 *           Andrew Kuo, 
 *           Calvin May, 
 *           Tom Zielinski
 *  Date: 04/09/2021
 *  Description: This is a custom control created for the MVCH System App Demo. This control is dynamically
 *               loaded onto the MainWindow.xaml, inside of the 'contentPanel' ContentPanel. This Control is
 *               loaded when the it is selected in the ListView Control that is loaded in th MainWindow.
 */

// Imports
using System.Windows;           // Default
using System.Windows.Controls;  // Default
using CrystalDecisions.CrystalReports.Engine; // Provide Access to the Crystal Reports Engine
using DBAS_5206_MVCH_SystemAppDemo.Reports;   // Provide Access to the custom Reports
using System.Data;              // These are here incase we want to run queries against our Database.
using System.Data.SqlClient;    // These are here incase we want to run queries against our Database.

namespace DBAS_5206_MVCH_SystemAppDemo.Controls
{
    /// <summary>
    /// Interaction logic for PhysicianPatientReportControl.xaml
    /// </summary>
    public partial class PhysicianPatientReportControl : UserControl
    {

        // Constructor
        public PhysicianPatientReportControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is an Event Handler. This code executes when this control is loaded.
        /// This handler is responsible for loading the correct Report onto the Crystal Report
        /// Viewer in the .xaml file for this control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Create a new ReportDocument Object, initializing with our PhysicianPatientReport CrystalReport.
            ReportDocument report = new PhysicianPatientReport();

            // Set the new report as the source for our Crystal Report Viewer control
            crystalReportsViewer1.ViewerCore.ReportSource = report;

            // Enable or disable Several options for the Crystal Report Viewer control
            crystalReportsViewer1.ViewerCore.EnableDrillDown = false;
            crystalReportsViewer1.ToggleSidePanel = SAPBusinessObjects.WPF.Viewer.Constants.SidePanelKind.None;
            crystalReportsViewer1.ShowLogo = false;
            crystalReportsViewer1.ShowToggleSidePanelButton = false;
            crystalReportsViewer1.ShowRefreshButton = true;

        }

    }
}
