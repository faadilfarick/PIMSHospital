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

namespace ThePIMS_Hospital.GUI.User
{
    /// <summary>
    /// Interaction logic for Doc_Edit.xaml
    /// </summary>
    public partial class User_Edit : Window
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public User_Edit()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            int userID = Convert.ToInt32(txtID.Text);
            var user = db.User.Find(userID);
            if (user != null)
            {
                txtID.Text = user.ID.ToString();
                txtName.Text = user.Name;                
                txtcontact.Text = user.contact.ToString();
                txtemail.Text = user.email;
                txtnic.Text = user.nic;
                txtdob.Text = user.dob;
                cmbRole.Text = user.role;
                btnFind.IsEnabled = false;
                txtID.IsEnabled = false;
                btnSave.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Invalid User ID");
            }
        }

        private void btnClaer_Click(object sender, RoutedEventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtcontact.Text = "";
            txtemail.Text = "";
            txtnic.Text = "";
            txtdob.Text = "";
            cmbRole.Text = "";

            btnFind.IsEnabled = true;
            txtID.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int userID = Convert.ToInt32(txtID.Text);
            BIZ.User user = db.User.Where(u => u.ID == userID).FirstOrDefault();
            user.ID = userID;
            user.Name = txtName.Text;
            user.contact = Convert.ToInt32(txtcontact.Text);
            user.email = txtemail.Text;
            user.nic = txtnic.Text;
            user.dob = txtdob.Text;
            user.role = cmbRole.Text;

            db.User.Attach(user);
            var entry = db.Entry(user);
            entry.State = System.Data.Entity.EntityState.Modified;
            var res = db.SaveChanges();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you sure you wanna delete?. Data will be lost permenently!", "Delete Confirm",
                MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
           
            {
                btnClaer_Click(null, null);
            }
            else
            {

            }
        }
    }
}
