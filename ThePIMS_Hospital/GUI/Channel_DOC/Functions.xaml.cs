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

namespace ThePIMS_Hospital.GUI.Channel_DOC
{
    /// <summary>
    /// Interaction logic for Functions.xaml
    /// </summary>
    public partial class Functions : Page
    {
        int conNum = 0;
        public Functions( int contact)
        {
            InitializeComponent();
            conNum = contact;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            AppoinmnetPage appoinmnetPage = new AppoinmnetPage(conNum);
            Channel_Doc _DOC = new Channel_Doc();
            _DOC.MainFrame = null;
           _DOC.MainFrame.Content = appoinmnetPage;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
