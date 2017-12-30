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
using ThePIMS_Hospital.DAL;

namespace ThePIMS_Hospital.GUI.Prescription
{
    /// <summary>
    /// Interaction logic for Presc_Add.xaml
    /// </summary>
    public partial class Presc_Add : Window
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Presc_Add()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string query = "addDoc '" + txtName.Text + "','" + txtQulalification.Text + "','" + txtContact.Text + "','" + txtFee.Text + "','" + cmbSpecilization.SelectedValue + "'";
            bool res = new SystemDAL().executeNonQuerys(query);

            if (res == true)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Pres_Edit _Edit = new Pres_Edit();
            _Edit.ShowDialog();
        }

        private void btnViewAkk_Click(object sender, RoutedEventArgs e)
        {
            Presc_All _All = new Presc_All();
            _All.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
