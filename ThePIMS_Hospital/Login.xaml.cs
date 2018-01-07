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
using ThePIMS_Hospital.GUI.Cashier;
using ThePIMS_Hospital.GUI.Channel_DOC;
using ThePIMS_Hospital.GUI.Patient;

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
                    if (user.role == "cashier")
                    {
                        Cashier ca = new Cashier();
                        this.Close();
                        ca.ShowDialog();
                    }
                    else
                    {
                        MainWindow main = new MainWindow(user.role, user.Name);
                        this.Close();
                        main.ShowDialog();
                    }
                    
                    
                }
            }

        }

        private void btnRegsterPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient_Reg reg = new Patient_Reg();
            reg.ShowDialog();
        }

        private void btnAppoinment_Click(object sender, RoutedEventArgs e)
        {
            Channel_Doc doc = new Channel_Doc();
            doc.ShowDialog();
        }
    }
}
