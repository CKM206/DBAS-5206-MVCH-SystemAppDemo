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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DBAS_5206_MVCH_SystemAppDemo.Reports;

namespace DBAS_5206_MVCH_SystemAppDemo.Controls
{
    /// <summary>
    /// Interaction logic for PhysicianPatientReportControl.xaml
    /// </summary>
    public partial class PhysicianPatientReportControl : UserControl
    {
        public PhysicianPatientReportControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ReportDocument report = new CrystalReport2();


            crystalReportsViewer1.ViewerCore.ReportSource = report;
            crystalReportsViewer1.ViewerCore.EnableDrillDown = false;
            crystalReportsViewer1.ToggleSidePanel = SAPBusinessObjects.WPF.Viewer.Constants.SidePanelKind.None;
            crystalReportsViewer1.ShowLogo = false;
            crystalReportsViewer1.ShowToggleSidePanelButton = false;
            crystalReportsViewer1.ShowRefreshButton = true;
        }
    }
}
