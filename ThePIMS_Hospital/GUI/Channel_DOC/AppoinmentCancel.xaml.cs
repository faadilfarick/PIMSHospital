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

namespace ThePIMS_Hospital.GUI.Channel_DOC
{
    /// <summary>
    /// Interaction logic for AppoinmentCancel.xaml
    /// </summary>
    public partial class AppoinmentCancel : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public AppoinmentCancel()
        {
            InitializeComponent();
        }
        int conNum;
        public AppoinmentCancel(int contact)
        {
            InitializeComponent();
            Appoinmnets(contact);
            conNum = contact;
        }

        private void Appoinmnets(int contact)
        {
            string query = "select * from [dbo].[Patient_Channel] where [Patient_Contact]='" + contact + "'";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);
            List<BIZ.Patient_Channel> channelList = new List<BIZ.Patient_Channel>();
            BIZ.Patient_Channel channel = new BIZ.Patient_Channel();
            while (reader.Read())
            {
                channel = new BIZ.Patient_Channel();
                channel.ID = Convert.ToInt32(reader[0]);
                channel.ChannelDate = Convert.ToDateTime(reader[1]);
                channel.ChannelTime = Convert.ToDateTime(reader[2]);
                channel.Fee = Convert.ToDecimal(reader[3]);
                channel.RoomNumber = Convert.ToInt32(reader[4]);
                channel.ChannelNumber = Convert.ToInt32(reader[5]);
                channelList.Add(channel);
            }
            dgvAppoinmnets.ItemsSource = channelList;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (id != 0)
            {
                if (MessageBox.Show("Are you sure you want to cancel the appoinment ?", "Cancellation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    //do no stuff
                   
                }
                else
                {
                    //do yes stuff
                    string query = "cancelAppoinment '" + id + "'";
                    bool res = new SystemDAL().executeNonQuerys(query);
                    if (res == true)
                    {
                        Appoinmnets(conNum);
                        MessageBox.Show("Successfully cancelled the appoinment");
                    }
                }

            }


        }

        int id;
        private void dgvProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgvAppoinmnets.SelectedItem != null)
                {
                    if (dgvAppoinmnets.SelectedItem is BIZ.Patient_Channel)
                    {
                        var row = (BIZ.Patient_Channel)dgvAppoinmnets.SelectedItem;

                        if (row != null)
                        {
                            id = row.ID;
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
