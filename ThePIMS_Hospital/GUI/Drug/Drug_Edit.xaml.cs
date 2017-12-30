using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        int DID = 0;
        public Drug_Edit(int id)
        {
            InitializeComponent();
            DID = id;
            cmbCategory.ItemsSource = db.Drug_Category.ToList();


            var row = db.Drug_Inventory.Find(id);
            txtName.Text = row.Name;
            txtDiscription.Text = row.Description;
            cmbCategory.SelectedValue = row.Drug_Category;
            txtSellingPrice.Text = row.Unit_Selling_Price.ToString();
            txtReorder.Text = row.Reorder_Level.ToString();
            txtbuyingPrice.Text = row.Unit_Buying_Price.ToString();
            txtType.Text = row.Drug_Type;
            txtShelf.Text = row.Shelf;
            string query = "select[Drug_Category_ID] from [dbo].[Drug_Inventory] where [ID]='" + id + "'";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);
            if (reader.Read())
                cmbCategory.SelectedValue = Convert.ToInt32(reader[0]);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string query = "updateDrugInventry '" + txtName.Text + "','" + txtDiscription.Text + "'," +
                "'" + Convert.ToDecimal(txtSellingPrice.Text) + "','" + Convert.ToInt32(txtReorder.Text) + "'," +
                "'" + Convert.ToDecimal(txtbuyingPrice.Text) + "','" + txtType.Text + "','" + txtShelf.Text + "'," +
                "'" + cmbCategory.SelectedValue + "','" + DID + "'";

            bool res = new SystemDAL().executeNonQuerys(query);
            if (res == true)
            {
                MessageBox.Show("Drug Updated");
               
            }
            else
            {
                MessageBox.Show("Something is not right please try again");
            }
        }
    }
}
