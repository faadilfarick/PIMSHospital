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
    /// Interaction logic for Doc_Edit.xaml
    /// </summary>
    public partial class Doc_Edit : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Doc_Edit()
        {
            InitializeComponent();
            cmbSpecilization.ItemsSource = db.Specilization.ToList();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            int docID = Convert.ToInt32(txtID.Text);
            var doc = db.Doctor.Find(docID);
            if (doc != null)
            {
                txtID.Text = doc.ID.ToString();
                txtName.Text = doc.Name;
                cmbSpecilization.SelectedValue = doc.Specilization.ID;
                //txtSpecilization.Text = doc.Specialization;
                txtQulalification.Text = doc.Qualification;
                txtFee.Text = doc.Fee.ToString();
                txtContact.Text = doc.Contact.ToString();
                btnFind.IsEnabled = false;
                txtID.IsEnabled = false;
                btnSave.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Invalid Doctor ID");
            }
        }

        private void btnClaer_Click(object sender, RoutedEventArgs e)
        {
            btnFind.IsEnabled = true;
            txtID.IsEnabled = true;
            btnSave.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int docID = Convert.ToInt32(txtID.Text);
            // BIZ.Doctor doctor = db.Doctor.Where(d => d.ID == docID).FirstOrDefault();
            // doctor.ID = docID;
            // doctor.Name = txtName.Text;
            //// doctor.Specialization = txtSpecilization.Text;
            // doctor.Qualification = txtQulalification.Text;
            // doctor.Fee = Convert.ToDecimal(txtFee.Text);
            // doctor.Contact = Convert.ToInt32(txtContact.Text);

            // db.Doctor.Attach(doctor);
            // var entry = db.Entry(doctor);
            // entry.State = System.Data.Entity.EntityState.Modified;
            // var res = db.SaveChanges();

            string query = "updateDoc '" + docID + "', '" + txtName.Text + "','" + txtQulalification.Text + "','" + txtContact.Text + "','" + txtFee.Text + "','" + cmbSpecilization.SelectedValue + "'";
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
    }
}
