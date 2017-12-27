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

namespace ThePIMS_Hospital.GUI.Patient
{
    /// <summary>
    /// Interaction logic for Patient_Edit.xaml
    /// </summary>
    public partial class Patient_Edit : Window
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Patient_Edit()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            int con = Convert.ToInt32(txtContact.Text);
            var patientDetails = db.Patient.Where(p => p.Contact == con).FirstOrDefault();
            if (patientDetails != null)
            {
                txtContact.Text = patientDetails.Contact.ToString();
                txtName.Text = patientDetails.Name;
                txtEmail.Text = patientDetails.Email;
                dtpDate.SelectedDate = Convert.ToDateTime(patientDetails.DOB);
                txtNIC.Text = patientDetails.NIC;
                txtContact.IsEnabled = false;
                btnFind.IsEnabled = false;
                btnSave.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Invalid contact Number Please register....");
            }
        }

        private void btnClaer_Click(object sender, RoutedEventArgs e)
        {
            txtContact.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            dtpDate.SelectedDate = null;
            txtNIC.Text = "";
            txtContact.IsEnabled = true;
            btnFind.IsEnabled = true;
            btnSave.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int con = Convert.ToInt32(txtContact.Text);
            BIZ.Patient patient = db.Patient.Where(p => p.Contact == con).FirstOrDefault();
            patient.Contact = Convert.ToInt32(txtContact.Text);
            patient.Name = txtName.Text;
            patient.Email = txtEmail.Text;
            patient.DOB = dtpDate.SelectedDate.ToString();
            patient.NIC = txtNIC.Text;

            db.Patient.Attach(patient);
            var entry = db.Entry(patient);
            entry.State = System.Data.Entity.EntityState.Modified;
            var res = db.SaveChanges();

            if (res == 1)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }


        }
    }
}
