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
using CrystalDecisions.CrystalReports.Engine;
using MahApps.Metro.Controls;
using SAPBusinessObjects.WPF.Viewer;

namespace ThePIMS_Hospital.GUI.Reporting
{
    /// <summary>
    /// Interaction logic for SalesReport_GUI.xaml
    /// </summary>
    public partial class SalesReport_GUI : MetroWindow
    {
        string date;
        public SalesReport_GUI()
        {
            InitializeComponent();
            date = DateTime.Now.ToShortDateString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvDate.DisplayDateEnd = DateTime.Now;
            crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
        }

        private void GetSalesRep()
        {
            try
            {

                DataSet ds = new DataSet();


                List<SalesReport> sal = new SalesReport(date).salesRpt();

                foreach (var items in sal)
                {

                    ds.Tables[0].Rows.Add
                        (new object[]{ 
                            items.ID.ToString(),
                            items.Name.ToString(),
                            items.TrackNo.ToString(),
                            items.Quantity.ToString(),
                             items.Price.ToString()
                    });

                }
                ReportDocument orep = new ReportDocument();
                orep.Load(System.AppDomain.CurrentDomain.BaseDirectory + @"GUI\Reporting\SalesReport_RPT.rpt");
                orep.SetDataSource(ds);

                SalesReport rpt = new SalesReport(date).rptSum();

                decimal tot = 0;
                if (rpt.Price != 0)
                    tot = rpt.Price;
                orep.SetParameterValue("Total", tot);
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

        private void btnGenarateRpt_Click(object sender, RoutedEventArgs e)
        {
            GetSalesRep();
        }
    }



}
