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
    /// Interaction logic for User_Add.xaml
    /// </summary>
    public partial class User_Add : Window
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public User_Add()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BIZ.User user = new BIZ.User();
                user.Name = txtName.Text;
                user.email = txtemail.Text;
                user.contact = Convert.ToInt32(txtcontact.Text);
                user.dob = txtdob.SelectedDate.Value;
                user.nic = txtnic.Text;
                user.role = cmbRole.Text;
                user.Password = txtPass.Password;
                db.User.Add(user);
                var res = db.SaveChanges();
                if (res == 1)
                {
                    MessageBox.Show("User Created Successfully");
                    clear();
                }
                else
                {
                    MessageBox.Show("Something went wrong please try again.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            User_Edit _Edit = new User_Edit();
            _Edit.ShowDialog();
        }

        private void btnViewAkk_Click(object sender, RoutedEventArgs e)
        {
            User_All _All = new User_All();
            _All.ShowDialog();
        }

        public void clear()
        {
            //txtID.Text = "";
            txtName.Text = "";
            txtcontact.Text = "";
            txtemail.Text = "";
            txtnic.Text = "";
            txtdob.Text = "";
            cmbRole.Text = "";
            txtPass.Password = "";
        }

    }
}
