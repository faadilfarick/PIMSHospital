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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThePIMS_Hospital.DAL;
using ThePIMS_Hospital.GUI.Cashier;
using ThePIMS_Hospital.GUI.Channel_DOC;
using ThePIMS_Hospital.GUI.Doctor;
using ThePIMS_Hospital.GUI.Drug;
using ThePIMS_Hospital.GUI.Patient;
using ThePIMS_Hospital.GUI.Prescription;
using ThePIMS_Hospital.GUI.Reporting;
using ThePIMS_Hospital.GUI.User;
//using ThePIMS_Hospital.GUI.Prescription;

namespace ThePIMS_Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public MainWindow()
        {
            InitializeComponent();
          
        }
        public MainWindow(string userRole,string userName)
        {
            InitializeComponent();
            txtuser.Text = "Hello " + userName + "";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Patient_Reg reg = new Patient_Reg();
            reg.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Doc_Reg reg = new Doc_Reg();
            reg.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Channel_Doc page = new Channel_Doc();
            page.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Presc_Add add = new Presc_Add();
            //add.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Drug_Add drug = new  Drug_Add();
            drug.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Presc_Add presc = new Presc_Add();
            presc.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Cashier cash = new Cashier();
            cash.ShowDialog();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.ShowDialog();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            User_Add usr = new User_Add();
            usr.ShowDialog();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgvAppoinmnets.ItemsSource = db.PatientChannel.Where(c => c.ChannelDate == DateTime.Now).ToList();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Report_Dash_GUI rpt = new Report_Dash_GUI();
            rpt.ShowDialog();
        }
    }
}
