using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ThePIMS_Hospital.GUI.Patient
{
    /// <summary>
    /// Interaction logic for Patient_All.xaml
    /// </summary>
    public partial class Patient_All : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Patient_All()
        {
            InitializeComponent();

            dgvPatients.ItemsSource = db.Patient.ToList();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                dgvPatients.ItemsSource = db.Patient.ToList();
            }
           
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                int serch = Convert.ToInt32(txtSearch.Text);
                dgvPatients.ItemsSource = db.Patient.Where(p => p.Contact == serch).ToList();
            }
        }
    }
}
