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

namespace ThePIMS_Hospital.GUI.Channel_DOC
{
    /// <summary>
    /// Interaction logic for Channel_Doc.xaml
    /// </summary>
    public partial class Channel_Doc : Window
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Channel_Doc()
        {
            InitializeComponent();
        }

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            int contact = Convert.ToInt32(txtContact.Text);
            BIZ.Patient p = db.Patient.Where(ps => ps.Contact == contact).FirstOrDefault();
            if (p != null)
            {
                AppoinmnetPage appoinmnetPage = new AppoinmnetPage(p.Contact);
                MainFrame.Content = appoinmnetPage;
                //Functions functions = new Functions(p.Contact);
                //MainFrame.Content = functions;
            }
            else
            {
                if(MainFrame.Content!=null)
                    MainFrame.Content = null;
                MessageBox.Show("Invalid Contact Number. Please Register First.");
            }
        }
    }
}
