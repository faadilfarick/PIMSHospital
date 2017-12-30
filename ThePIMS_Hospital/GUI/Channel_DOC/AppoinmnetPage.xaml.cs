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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThePIMS_Hospital.DAL;

namespace ThePIMS_Hospital.GUI.Channel_DOC
{
    /// <summary>
    /// Interaction logic for AppoinmnetPage.xaml
    /// </summary>
    public partial class AppoinmnetPage : Page
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public AppoinmnetPage()
        {
            InitializeComponent();
            cmbDocs.ItemsSource = db.Doctor.ToList();
        }
        int contact = 0;
        public AppoinmnetPage(int num)
        {

            InitializeComponent();
            contact = num;
            BIZ.Patient patient = db.Patient.Where(p => p.Contact == num).FirstOrDefault();

            txtContact.Text = patient.Contact.ToString();
            txtName.Text = patient.Name;
            txtEmail.Text = patient.Email;
            dtpDate.SelectedDate = Convert.ToDateTime(patient.DOB);
            txtNIC.Text = patient.NIC;

            cmbDocs.ItemsSource = db.Doctor.ToList();
        }

        private void cmbDocs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDocs.SelectedIndex != -1)
            {
                int DocID = Convert.ToInt32(cmbDocs.SelectedValue);
                //BIZ.Doctor doctor = db.Doctor.Where(d => d.ID == DocID).FirstOrDefault();

                //txtSpeclization.Text = doctor.Specilization.Name;
                var doc = db.Doctor.Find(DocID);

                decimal HospitalFee = 500;
                decimal TotFee = doc.Fee + HospitalFee;
                txtamount.Text = TotFee.ToString();

                string query = "SELECT Specilizations.Name FROM Doctors INNER JOIN Specilizations" +
                        " ON Doctors.Specilization_ID = Specilizations.ID where Doctors.ID = '" + DocID + "'";
                SqlDataReader reader = new SystemDAL().executeQuerys(query);
                if (reader.Read())
                {
                    txtSpeclization.Text = reader[0].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int DocID = Convert.ToInt32(cmbDocs.SelectedValue);
            var doc = db.Doctor.Find(DocID);

            decimal HospitalFee = 500;
            decimal TotFee = doc.Fee + HospitalFee;

            int channelNum = 1;

            string query = "GetAppoinmentNum '" + DocID + "','" + dtpChannelDate.SelectedDate.ToString() + "'";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);
            if (reader.Read())
            {
                string a = reader[0].ToString();
                if (a != "")
                    channelNum = Convert.ToInt32(reader[0]) + 1;
            }

            int roomNum = 0;
            string query1 = "makeAppoinment '" + dtpChannelDate.SelectedDate + "','" + DateTime.Now.ToShortTimeString() + "','" + TotFee + "','" + roomNum + "','" + channelNum + "','" + Convert.ToInt32(txtContact.Text) + "','" + DocID + "'";
            bool res = new SystemDAL().executeNonQuerys(query1);
            if (res == true)
            {
                MessageBox.Show("You have successfully Made the Appoinment your Appoinment number is : " + channelNum);
            }
            else
            {
                MessageBox.Show("Something isnt ok please try again");
            }

            // BIZ.Patient_Channel _Channel = new BIZ.Patient_Channel();
            // //_Channel.ChannelDate = dtpChannelDate.SelectedDate.ToString();
            // //_Channel.ChannelTime = DateTime.Now.ToShortTimeString();
            // _Channel.Fee = TotFee;
            // _Channel.RoomNumber = 0;
            // _Channel.ChannelNumber = channelNum;

            //// _Channel.p

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            
            AppoinmentCancel appoinmentCancel = new AppoinmentCancel(contact);
            appoinmentCancel.ShowDialog();
        }
    }
}
