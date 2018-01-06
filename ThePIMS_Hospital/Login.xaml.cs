using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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

namespace ThePIMS_Hospital
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                this.ShowMessageAsync("Required", "please enter username");
                txtUsername.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                this.ShowMessageAsync("Required", "please enter password");
                txtPassword.Focus();
            }
            else
            {
                var user = db.User.Where(u => u.email == txtUsername.Text && u.Password == txtPassword.Password).FirstOrDefault();
                if(user==null||string.IsNullOrWhiteSpace(user.role)&& string.IsNullOrWhiteSpace(user.Name))
                {
                    this.ShowMessageAsync("Invalid Attempt", "Please check the login Details and try again");
                }
                else
                {
                    
                    MainWindow main = new MainWindow(user.role,user.Name);
                    this.Close();
                    main.ShowDialog();
                }
            }

        }
    }
}
