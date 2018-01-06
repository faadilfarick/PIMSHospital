using MahApps.Metro.Controls;
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
    /// Interaction logic for Drug_Purchase.xaml
    /// </summary>
    public partial class Drug_Purchase : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Drug_Purchase()
        {
            InitializeComponent();
            cmbDrugName.ItemsSource = db.Drug_Inventory.ToList();
            cmbSupplier.ItemsSource = db.Drug_Supplier.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string qury = "PurchaseDrugInventry '" + cmbDrugName.SelectedValue + "','" + DateTime.Now + "','" + Convert.ToDecimal(txtQuantity.Text) + "','" + cmbSupplier.SelectedValue + "'";
            bool res = new SystemDAL().executeNonQuerys(qury);

            if (res == true)
            {
                MessageBox.Show("New Stock Purchase Successful...");
            }
            else
            {
                MessageBox.Show("Something Went Wrong....please try again.");
            }

        }
    }
}
