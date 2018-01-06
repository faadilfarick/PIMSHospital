using MahApps.Metro.Controls;
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

namespace ThePIMS_Hospital.GUI.User
{
    /// <summary>
    /// Interaction logic for User_All.xaml
    /// </summary>
    public partial class User_All : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public User_All()
        {
            InitializeComponent();
            var user = from u in db.User
                      select new { u.ID, u.Name, u.contact, u.email, u.nic, u.dob, u.role };


            dgvUsers.ItemsSource = db.User.ToList();

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                int id = Convert.ToInt32(txtSearch.Text);
                dgvUsers.ItemsSource = db.User.Where(u => u.ID == id).ToList();
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtSearch.Text))
                dgvUsers.ItemsSource = db.User.ToList();

        }
    }
}
