using CrystalDecisions.CrystalReports.Engine;
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
    /// Interaction logic for SalesReportMonthly_GUI.xaml
    /// </summary>
    public partial class SalesReportMonthly_GUI : Window
    {
        public SalesReportMonthly_GUI()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetSalesRep();
            crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;

        }
        private void GetSalesRep()
        {
            try
            {

                DataSet ds = new DataSet();


                List<SalesReport> sal = new SalesReport().salesRptMonthlyRpt();

                foreach (var items in sal)
                {

                    ds.Tables["MonthlySalesDs"].Rows.Add
                        (new object[]{ 
                            items.Year.ToString(),
                            items.Month,
                            items.Price
                    });

                }
                ReportDocument orep = new ReportDocument();
                orep.Load(System.AppDomain.CurrentDomain.BaseDirectory + @"GUI\Reporting\SalesReportMonthly_RPT.rpt");
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
    }
}
