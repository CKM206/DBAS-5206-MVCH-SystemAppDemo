/**
 *  Document: COSControls.xaml.cs
 *  Authors: Kristopher Hankey, 
 *           Andrew Kuo, 
 *           Calvin May, 
 *           Tom Zielinski
 *  Date: 04/09/2021
 *  Description: This is a custom control created for the MVCH System App Demo. This control is dynamically
 *               loaded onto the MainWindow.xaml, inside of the 'controlPanel' Grid, depending on the position 
 *               of the User currently logged into the application. This Control will only load if the logged 
 *               in user has a position of Hospital Administrator and will provide access to the functionality need by that 
 *               Position. This Control is empty for now, it's main purpose is to demonstrate the ability to swap data access
 *               depending on position.
 */

// Imports
using System.Windows.Controls;  // Default


namespace DBAS_5206_MVCH_SystemAppDemo.Controls
{

    /// <summary>
    /// Interaction logic for COSControls.xaml
    /// </summary>
    public partial class COSControls : UserControl
    {
        // This is a reference to MainWindows contentPanel (which we passed via the COSControls constructor),
        //-this is what we will use to dynamically load the content section of the MainWindow.
        private ContentControl content;

        /// <summary>
        /// COSControls(ContentControl) - This is the COSControls Constructor, when the MainWindow calls this it will pass 
        ///                             its ContentControl Object so that this Control can dynamically load content.
        /// </summary>
        /// <param name="contentPanel">A ContentControl passed from MainWindow.xaml</param>
        public COSControls(ContentControl contentPanel)
        {
            InitializeComponent();
            content = contentPanel;
        }
    }
}
