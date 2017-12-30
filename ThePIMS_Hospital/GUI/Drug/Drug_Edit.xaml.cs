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

namespace ThePIMS_Hospital.GUI.Drug
{
    /// <summary>
    /// Interaction logic for Drug_Edit.xaml
    /// </summary>
    public partial class Drug_Edit : Window
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Drug_Edit()
        {           
            InitializeComponent();

            cmbCategory.ItemsSource = db.Drug_Category.ToList();
        }
        public Drug_Edit(int id)
        {
            InitializeComponent();

            cmbCategory.ItemsSource = db.Drug_Category.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
