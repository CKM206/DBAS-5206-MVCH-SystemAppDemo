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
        public static string EmployeeId { get; set; }

        private static string position;

        public MainWindow()
        {
            InitializeComponent();
            // Set the ContentPanel's Content to the Control
            Control homeControl = new HomeControl();
            this.contentPanel.Content = homeControl;
            PopulateEmployeeInfo();
        }
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            // Close the Main window
            this.Close();
        }

        private void lvMenuOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // listView object is equal to the sender who is the lvMenuOptions ListView Object
            ListView listView = e.Source as ListView;

            if (listView != null)
            {
                if (listView.SelectedItem.Equals(lviHome))
                {
                    // Set the Page Title
                    tblkPageTitle.Text = "Home";

                    // Set the ContentPanel's Content to the Control
                    Control homeControl = new HomeControl();
                    this.contentPanel.Content = homeControl;
                    
                }
                else if (listView.SelectedItem.Equals(lviPhysicianPatientReport))
                {
                    // Set the Page Title
                    tblkPageTitle.Text = "Physician Patient Report";

                    // Set the ContentPanel's Content to the Control
                    Control physicianPatientReportControl = new PhysicianPatientReportControl();
                    this.contentPanel.Content = physicianPatientReportControl;
                }
                else if (listView.SelectedItem.Equals(lviRoomUtilizationReport))
                {
                    // Set the Page Title
                    tblkPageTitle.Text = "Room Utilization Report";

                    // Set the ContentPanel's Content to the Control
                    Control roomUtilizationControl = new RoomUtilizationControl();
                    this.contentPanel.Content = roomUtilizationControl;
                }

            }
        }


        private void PopulateEmployeeInfo()
        {
            // Find out which User is logged in
            if (int.Parse(EmployeeId) == 3)
            {
                lblEmployeeName.Content = "Xulia, Mahir";
                position = "Clerk";
                lblEmployeePosition.Content = position;
            }
            else
            {
                lblEmployeeName.Content = "Ms. Baker";
                position = "Hospital Administrator";
                lblEmployeePosition.Content = position;

            }
        }

    }
}
