using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ThePIMS_Hospital.GUI.Cashier
{
    /// <summary>
    /// Interaction logic for Cashier.xaml
    /// </summary>
    public partial class Cashier : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Cashier()
        {
            InitializeComponent();
        }

        private void cmbPaymentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPaymentType.SelectedIndex == 0)
            {
                txtCash.Visibility = Visibility.Visible;
                tbCash.Visibility = Visibility.Visible;
            }
            else
            {
                txtCash.Visibility = Visibility.Hidden;
                tbCash.Visibility = Visibility.Hidden;
            }
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int track = Convert.ToInt32(txtTrackNo.Text);
                dgvPresDetails.ItemsSource = db.Prescription_details.Where(p => p.TrackNo == track).ToList();

                var sum = db.Prescription_details.Where(p => p.TrackNo == track).Sum(p1 => p1.Price);
                txtTotal.Text = sum.ToString();

                string query = "select [Patient_Contact] from  [dbo].[Prescriptions] where [TrackNo]='" + track + "'";
                SqlDataReader reader = new SystemDAL().executeQuerys(query);
                if (reader.Read())
                {
                    txtContact.Text = reader[0].ToString();
                }

                var priscription = db.Prescription.Where(p => p.TrackNo == track).FirstOrDefault();


            }
            catch (Exception)
            {

                MessageBox.Show("Invalid Tracking No.");
            }

        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            int track = Convert.ToInt32(txtTrackNo.Text);
            var priscription = db.Prescription.Where(p => p.TrackNo == track).FirstOrDefault();
            var sum = db.Prescription_details.Where(p => p.TrackNo == track).Sum(p1 => p1.Price);
            if (cmbPaymentType.SelectedIndex == 0)
            {
                decimal cashPaid = Convert.ToDecimal(txtCash.Text);
                if (cashPaid < sum)
                {
                    MessageBox.Show("Cash Deficit");
                }
                else if (cashPaid > sum)
                {
                    Decimal bal = cashPaid - sum;
                    MessageBox.Show("Balance is : " + bal);
                    if (cmbPaymentType.SelectedIndex != -1)
                    {
                        string query1 = "PayForPriscription '" + priscription.ID + "','" + track + "','" + sum + "'," +
                   "'" + DateTime.Now + "','" + cmbPaymentType.Text + "','" + Convert.ToInt32(txtContact.Text) + "'";
                        bool res = new SystemDAL().executeNonQuerys(query1);
                        if (res == true)
                        {

                            MessageBox.Show("Payment Success");

                        }
                        else
                        {
                            MessageBox.Show("Payment Failed");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select payment Type");
                    }
                }
                else if (cashPaid == sum)
                {
                    if (cmbPaymentType.SelectedIndex != -1)
                    {
                        string query1 = "PayForPriscription '" + priscription.ID + "','" + track + "','" + sum + "'," +
                   "'" + DateTime.Now + "','" + cmbPaymentType.Text + "','" + Convert.ToInt32(txtContact.Text) + "'";
                        bool res = new SystemDAL().executeNonQuerys(query1);
                        if (res == true)
                        {

                            MessageBox.Show("Payment Success");

                        }
                        else
                        {
                            MessageBox.Show("Payment Failed");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select payment Type");
                    }
                }




            }
            else if(cmbPaymentType.SelectedIndex==1)
            {
                string query1 = "PayForPriscription '" + priscription.ID + "','" + track + "','" + sum + "'," +
                   "'" + DateTime.Now + "','" + cmbPaymentType.Text + "','" + Convert.ToInt32(txtContact.Text) + "'";
                bool res = new SystemDAL().executeNonQuerys(query1);
                if (res == true)
                {

                    MessageBox.Show("Payment Success");

                }
                else
                {
                    MessageBox.Show("Payment Failed");
                }
            }
        }
    }
}
