using MahApps.Metro.Controls;
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

namespace ThePIMS_Hospital.GUI.Doctor
{
    /// <summary>
    /// Interaction logic for Doc_Reg.xaml
    /// </summary>
    public partial class Doc_Reg : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Doc_Reg()
        {
            InitializeComponent();
            cmbSpecilization.ItemsSource = db.Specilization.ToList();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //BIZ.Doctor doctor = new BIZ.Doctor();
            //doctor.Name = txtName.Text;
            //// doctor.Specialization = txtSpecilization.Text;
            //doctor.Specilization.ID = Convert.ToInt32(cmbSpecilization.SelectedValue);
            //doctor.Qualification = txtQulalification.Text;
            //doctor.Fee = Convert.ToDecimal(txtFee.Text);
            //doctor.Contact = Convert.ToInt32(txtContact.Text);

            //db.Doctor.Add(doctor);
            //var res= db.SaveChanges();
            string query = "addDoc '" + txtName.Text + "','" + txtQulalification.Text + "','" + txtContact.Text + "','" +  txtFee.Text + "','" + cmbSpecilization.SelectedValue + "'";
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
            Doc_Edit _Edit = new Doc_Edit();
            _Edit.ShowDialog();
        }

        private void btnViewAkk_Click(object sender, RoutedEventArgs e)
        {
            Doc_All _All = new Doc_All();
            _All.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
