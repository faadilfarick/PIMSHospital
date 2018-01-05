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

namespace ThePIMS_Hospital.GUI.Reporting
{
    /// <summary>
    /// Interaction logic for DrugPurchaseChart_GUI.xaml
    /// </summary>
    public partial class DrugPurchaseChart_GUI : MetroWindow
    {
        public DrugPurchaseChart_GUI()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetSalesRepAll();
            crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;

        }
        private void GetSalesRepAll()
        {
            try
            {

                DataSet ds = new DataSet();

                List<Drug_Report> pro = new Drug_Report().DrugPurchasedMontlyAll();

                foreach (var items in pro)
                {
                    items.Month = items.Year.ToString() + "-" + items.Month;
                    ds.Tables["DrugPurchaseDS"].Rows.Add
                        (new object[]{ 
                            items.Year,
                            items.Month,
                            items.DrugName,
                            items.Category,
                            items.Qty
                    });

                }
                ReportDocument orep = new ReportDocument();
                orep.Load(System.AppDomain.CurrentDomain.BaseDirectory + @"GUI\Reporting\DrugPurchaseChart.rpt");
                orep.SetDataSource(ds);

                //SalesReport rpt = new SalesReport(date).rptSum();

                //decimal tot = 0;
                //if (rpt.Price != 0)
                //    tot = rpt.Price;
                //orep.SetParameterValue("Total", tot);
                //orep.SetParameterValue("Date", date);
                crystalReportsViewer1.ViewerCore.ReportSource = orep;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenarateRptAll_Click(object sender, RoutedEventArgs e)
        {
            GetSalesRepAll();
        }
    }

}
