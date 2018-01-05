using CrystalDecisions.CrystalReports.Engine;
using MahApps.Metro.Controls;
using SAPBusinessObjects.WPF.Viewer;
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
using ThePIMS_Hospital.BIZ;
using ThePIMS_Hospital.DAL;

namespace ThePIMS_Hospital.GUI.Reporting
{
    /// <summary>
    /// Interaction logic for PurchaseReport_GUI.xaml
    /// </summary>
    public partial class PurchaseReport_GUI : MetroWindow
    {
        string date;
        ApplicationDbContext db = new ApplicationDbContext();
        public PurchaseReport_GUI()
        {
            InitializeComponent();
            date = DateTime.Now.ToShortDateString();
        }

        private void btnGenarateRpt_Click(object sender, RoutedEventArgs e)
        {
            GetPurchaseRep();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvDate.DisplayDateEnd = DateTime.Now;
            crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
        }
        decimal priceTot = 0;
        private void GetPurchaseRep()
        {
            priceTot = 0;
            try
            {

                DataSet ds = new DataSet();


                List<Purchase_Report> sal = new Purchase_Report(date).purchaseRpt();

                foreach (var items in sal)
                {
                    var drugDetails = db.Drug_Inventory.Where(d => d.Name == items.DrugName).FirstOrDefault();

                    items.Price = drugDetails.Unit_Buying_Price * items.Quantity;
                    priceTot = priceTot + items.Price;
                    ds.Tables[1].Rows.Add
                        (new object[]{ 
                            items.ID.ToString(),
                            items.DrugName.ToString(),
                            items.Quantity.ToString(),
                            items.Supplier.ToString(),
                           items.Price.ToString()

                    });

                }
                ReportDocument orep = new ReportDocument();
                orep.Load(System.AppDomain.CurrentDomain.BaseDirectory + @"GUI\Reporting\PurchaseReport_RPT.rpt");
                orep.SetDataSource(ds);

                //SalesReport rpt = new SalesReport(date).rptSum();

                //decimal tot = 0;
                //if (rpt.Price != 0)
                //    tot = rpt.Price;
                orep.SetParameterValue("Total", priceTot);
                orep.SetParameterValue("Date", date);
                crystalReportsViewer1.ViewerCore.ReportSource = orep;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            date = Convert.ToDateTime(dgvDate.SelectedDate).ToShortDateString();

        }
    }
}
