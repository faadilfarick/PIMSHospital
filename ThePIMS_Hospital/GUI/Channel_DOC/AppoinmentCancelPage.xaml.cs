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

namespace ThePIMS_Hospital.GUI.Channel_DOC
{
    /// <summary>
    /// Interaction logic for AppoinmentCancelPage.xaml
    /// </summary>
    public partial class AppoinmentCancelPage : Page
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public AppoinmentCancelPage()
        {
            InitializeComponent();
        }
        public AppoinmentCancelPage(int contact)
        {
            InitializeComponent();
            dgvAppoinmnets.ItemsSource = db.PatientChannel.Where(p => p.Patient.Contact == contact);
        }

        private void dgvProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
