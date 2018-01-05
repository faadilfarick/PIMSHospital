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

namespace ThePIMS_Hospital.GUI.Prescription
{
    /// <summary>
    /// Interaction logic for Presc_Add.xaml
    /// </summary>
    public partial class Presc_Add : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Presc_Add()
        {
            InitializeComponent();
            cmbPatient.ItemsSource = db.Patient.ToList();
            cmbDoctor.ItemsSource = db.Doctor.ToList();
            cmbDrug.ItemsSource = db.Drug_Inventory.ToList();
          
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //string query = "addPresc '" + txtDescription.Text + "','" + txtDeseaseType.Text + "','" + txtDescription.Text + "','" + 
            //    cmbPatient.SelectedValue + "','" + cmbDoctor.SelectedValue + "','" + cmbPrescDetails.SelectedValue +  "'";
            //bool res = new SystemDAL().executeNonQuerys(query);

            //if (res == true)
            //{
            //    MessageBox.Show("Success");
            //}
            //else
            //{
            //    MessageBox.Show("Failed");
            //}
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //Pres_Edit _Edit = new Pres_Edit();
            //_Edit.ShowDialog();
        }

        private void btnViewAkk_Click(object sender, RoutedEventArgs e)
        {
            //Presc_All _All = new Presc_All();
            //_All.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        int trackNo = 0;
        private void btnAddtoList_Click(object sender, RoutedEventArgs e)
        {
         
            if (dgvPresc.ItemsSource == null)
            {
                trackNo = 0;
                try
                {
                    trackNo = db.Prescription.Max(p => p.TrackNo) + 1;
                }
                catch (Exception)
                {

                    trackNo = 1;
                }

             
                string query = "addPresc1 '" + txtDeseaseType.Text + "','" + txtDescription.Text + "','" +
                    "" + cmbPatient.SelectedValue + "','" + cmbDoctor.SelectedValue + "','" + trackNo + "','"+DateTime.Now.ToShortDateString()+"'";
                bool res = new SystemDAL().executeNonQuerys(query);

                string qury = "AddDrugToList '" + cmbDrug.SelectedValue + "','" + txtDescription.Text + "','" + Convert.ToInt32(txtQty.Text) + "','" + trackNo + "','" + Convert.ToDecimal(txtPrice.Text) + "'";
                bool res1 = new SystemDAL().executeNonQuerys(qury);

                dgvPresc.ItemsSource = db.Prescription_details.Where(p => p.TrackNo == trackNo).ToList();

            }
            else
            {
                string qury = "AddDrugToList '" + cmbDrug.SelectedValue + "','" + txtDescription.Text + "','" + Convert.ToInt32(txtQty.Text) + "','" + trackNo + "','" + Convert.ToDecimal(txtPrice.Text) + "'";
                bool res1 = new SystemDAL().executeNonQuerys(qury);
                dgvPresc.ItemsSource = db.Prescription_details.Where(p => p.TrackNo == trackNo).ToList();
            }
        }

        private void txtQty_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQty.Text))
            {
                int drugId = Convert.ToInt32(cmbDrug.SelectedValue);

                var drug = db.Drug_Inventory.Find(drugId);

                decimal price = drug.Unit_Selling_Price;
                int qty = Convert.ToInt32(txtQty.Text);

                decimal priceTosave = price * qty;

                txtPrice.Text = priceTosave.ToString();
            }
           
        }

        private void cmbDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // MessageBox.Show(cmbDoctor.SelectedValue + " " + cmbDoctor.Text);
        }
    }
}
