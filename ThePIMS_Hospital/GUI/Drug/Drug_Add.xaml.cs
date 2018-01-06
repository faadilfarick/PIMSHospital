using MahApps.Metro.Controls;
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
    /// Interaction logic for Drug_Add.xaml
    /// </summary>
    public partial class Drug_Add : MetroWindow
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Drug_Add()
        {
            InitializeComponent();
            cmbCategory.ItemsSource = db.Drug_Category.ToList();

            dgvProductList.ItemsSource = db.Drug_Inventory.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string query = "addDrugInventry '" + txtName.Text + "','" + txtDiscription.Text + "'," +
                "'" + Convert.ToDecimal(txtSellingPrice.Text) + "','" + Convert.ToInt32(txtReorder.Text) + "'," +
                "'" + Convert.ToDecimal(txtbuyingPrice.Text) + "','" + txtType.Text + "','" + txtShelf.Text + "'," +
                "'" + cmbCategory.SelectedValue + "'";

            bool res = new SystemDAL().executeNonQuerys(query);
            if (res == true)
            {
                MessageBox.Show("Drug Added");
                dgvProductList.ItemsSource = db.Drug_Inventory.ToList();
            }
            else
            {
                MessageBox.Show("Something is not right please try again");
            }

        }
        int id = 0;

        private void dgvProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgvProductList.SelectedItem != null)
                {
                    if (dgvProductList.SelectedItem is BIZ.Drug_Inventory)
                    {
                        var row = (BIZ.Drug_Inventory)dgvProductList.SelectedItem;

                        if (row != null)
                        {

                             id = row.ID;
                            
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
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (id != 0)
            {
                Drug_Edit _Edit = new Drug_Edit(id);
                _Edit.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a drug from Datagrid to edit");
            }
         
        }

        private void clear()
        {
            txtName.Text = "";
            txtDiscription.Text = "";
            
            txtSellingPrice.Text = "";
            txtReorder.Text = "";
            txtbuyingPrice.Text = "";
            txtType.Text = "";
            txtShelf.Text = "";
            id = 0;
            cmbCategory.SelectedIndex = -1;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btnPurchase_Click(object sender, RoutedEventArgs e)
        {
            Drug_Purchase pur = new Drug_Purchase();
            pur.ShowDialog();
        }
    }
}
