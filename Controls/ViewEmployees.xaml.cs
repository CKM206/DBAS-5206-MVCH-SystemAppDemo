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
using System.Data;
using System.Data.SqlClient;

namespace DBAS_5206_MVCH_SystemAppDemo.Controls
{
    /// <summary>
    /// Interaction logic for ViewEmployees.xaml
    /// </summary>
    public partial class ViewEmployees : UserControl
    {
        public ViewEmployees()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            try
            {


                string cString = Properties.Settings.Default.MVCH_DBConnectionString;

                string query = "Select * FROM viewPhysicianPatient;";

                SqlConnection con = new SqlConnection(cString);
                con.Open();

                SqlCommand command = new SqlCommand(query, con);

                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable dt = new DataTable("Employees");

                da.Fill(dt);

                con.Close();

                dgPhysicianPatientTable.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
