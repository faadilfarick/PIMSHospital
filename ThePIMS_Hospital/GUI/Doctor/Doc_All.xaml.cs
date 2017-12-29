using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ThePIMS_Hospital.GUI.Doctor
{
    /// <summary>
    /// Interaction logic for Doc_All.xaml
    /// </summary>
    public partial class Doc_All : Window
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Doc_All()
        {
            InitializeComponent();
            var doc = from d in db.Doctor
                      join s in db.Specilization on d.Specilization.ID equals s.ID
                      select new { d.ID, d.Name, d.Qualification, d.Fee,d.Specilization };
            //foreach (var docs in doc)
            //    MessageBox.Show(docs.Specilization.Name);


            dgvDocs.ItemsSource = db.Doctor.ToList();
            //dgvDocs.ItemsSource = from d in db.Doctor
            //                      join s in db.Specilization on d.Specilization.ID equals s.ID
            //                      select new { d.ID,d.Name,d.Qualification,d.Fee,d.Specilization };

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                int id = Convert.ToInt32(txtSearch.Text);
                dgvDocs.ItemsSource = db.Doctor.Where(d => d.ID == id).ToList();
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtSearch.Text))
                dgvDocs.ItemsSource = db.Doctor.ToList();

        }
    }
}
