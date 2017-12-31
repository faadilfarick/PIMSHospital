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
using ThePIMS_Hospital.BIZ;

namespace ThePIMS_Hospital.GUI.Patient
{
    /// <summary>
    /// Interaction logic for Patient_Reg.xaml
    /// </summary>
    public partial class Patient_Reg : Window
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Patient_Reg()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BIZ.Patient patient = new BIZ.Patient();
            patient.Contact = Convert.ToInt32(txtContact.Text);
            patient.Name = txtName.Text;
            patient.Email = txtEmail.Text;
            patient.DOB = dtpDate.SelectedDate.ToString();
            patient.NIC = txtNIC.Text;

            try
            {
                var patie = db.Patient.Where(p => p.Contact == patient.Contact).FirstOrDefault();
                if (patie != null)
                {
                    MessageBox.Show("The Number : " + patient.Contact + " is already registered please Use that number for appointments. thnak you...");
                }
                else
                {
                    db.Patient.Add(patient);
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Patient_Edit _Edit = new Patient_Edit();
            _Edit.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewAkk_Click(object sender, RoutedEventArgs e)
        {
            Patient_All _All = new Patient_All();
            _All.ShowDialog();
        }
    }
}
