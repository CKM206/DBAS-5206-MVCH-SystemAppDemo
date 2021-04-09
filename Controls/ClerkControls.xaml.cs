/**
 *  Document: ClerkControls.xaml.cs
 *  Authors: Kristopher Hankey, 
 *           Andrew Kuo, 
 *           Calvin May, 
 *           Tom Zielinski
 *  Date: 04/09/2021
 *  Description: This is a custom control created for the MVCH System App Demo. This control is dynamically
 *               loaded onto the MainWindow.xaml, inside of the 'controlPanel' Grid, depending on the position 
 *               of the User currently logged into the application. This Control will only load if the logged 
 *               in user has a position of Clerk and will provide access to the functionality need by the Clerk 
 *               Positions.
 */

// Imports
using System.Windows.Controls; // Default


namespace DBAS_5206_MVCH_SystemAppDemo.Controls
{
    /// <summary>
    /// Interaction logic for ClerkControls.xaml
    /// </summary>
    public partial class ClerkControls : UserControl
    {
        // This is a reference to MainWindows contentPanel (which we passed via the ClerkControls constructor),
        //-this is what we will use to dynamically load the content section of the MainWindow.
        private ContentControl content;


        /// <summary>
        /// ClerkControls(ContentControl) - This is the ClerkControls Constructor, when the MainWindow calls this it will pass 
        ///                               its ContentControl Object so that this Control can dynamically load content.
        /// </summary>
        /// <param name="contentPanel">A ContentControl passed from MainWindow.xaml</param>
        public ClerkControls(ContentControl contentPanel)
        {
            InitializeComponent();
            // Get the reference to the contentPanel
            content = contentPanel;
        }

        /// <summary>
        /// This is an Event Handler for the SelectionChanged event of the lvMenuOptions ListView.
        /// This allows Users to select an Item from the ListView and dynamically load content based
        /// on the Chosen Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvMenuOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // listView object is equal to the sender who is the lvMenuOptions ListView Object
            ListView listView = e.Source as ListView;

            // Make sure that listView is not null before proceeding to prevent exceptions.
            if (listView != null)
            {
                // Selected Item was 'Home'
                if (listView.SelectedItem.Equals(lviHome))
                {
                    // Set the Page Title
                    //tblkPageTitle.Text = "Home";

                    // Set the ContentPanel's Content to the Control
                    Control homeControl = new HomeControl();
                    this.content.Content = homeControl;

                }
                // Selected Item was 'Physician Patient Report'
                else if (listView.SelectedItem.Equals(lviPhysicianPatientReport))
                {
                    // Set the Page Title
                    //tblkPageTitle.Text = "Physician Patient Report";

                    // Set the ContentPanel's Content to the Control
                    Control physicianPatientReportControl = new PhysicianPatientReportControl();
                    this.content.Content = physicianPatientReportControl;
                }
                // Selected Item was 'Room Utilization Report'
                else if (listView.SelectedItem.Equals(lviRoomUtilizationReport))
                {
                    // Set the Page Title
                    //tblkPageTitle.Text = "Room Utilization Report";

                    // Set the ContentPanel's Content to the Control
                    Control roomUtilizationControl = new RoomUtilizationControl();
                    this.content.Content = roomUtilizationControl;
                }

            }
        }
    }
}
