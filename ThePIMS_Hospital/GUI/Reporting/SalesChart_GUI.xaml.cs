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
    /// Interaction logic for SalesChart_GUI.xaml
    /// </summary>
    public partial class SalesChart_GUI : MetroWindow
    {

        string date,date2;

        public SalesChart_GUI()
        {
            InitializeComponent();
            date = DateTime.Now.AddMonths(-6).ToShortDateString();
            date2 = DateTime.Now.ToShortDateString();
        }

        private void btnGenarateRpt_Click(object sender, RoutedEventArgs e)
        {
            GetSalesRep();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvDate.DisplayDateEnd = DateTime.Now;
            dgvDate2.DisplayDateEnd = DateTime.Now;

            dgvDate.SelectedDate = Convert.ToDateTime(date);
            dgvDate2.SelectedDate = Convert.ToDateTime(date2);
            crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
        }

        private void dgvDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            date = Convert.ToDateTime(dgvDate.SelectedDate).ToShortDateString();
        }

        private void dgvDate2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            date2 = Convert.ToDateTime(dgvDate2.SelectedDate).ToShortDateString();

        }


        private void GetSalesRep()
        {
            try
            {

                DataSet ds = new DataSet();


                List<SalesReport> sal = new SalesReport(date,date2).salesRptChart();

                foreach (var items in sal)
                {

                    ds.Tables[2].Rows.Add
                        (new object[]{ 
                            items.Date.ToString(),
                            items.Price
                    });

                }
                ReportDocument orep = new ReportDocument();
                orep.Load(System.AppDomain.CurrentDomain.BaseDirectory + @"GUI\Reporting\SalesChart_RPT.rpt");
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
