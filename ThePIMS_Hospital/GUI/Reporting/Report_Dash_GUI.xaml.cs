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

namespace ThePIMS_Hospital.GUI.Reporting
{
    /// <summary>
    /// Interaction logic for Report_Dash_GUI.xaml
    /// </summary>
    public partial class Report_Dash_GUI : MetroWindow
    {
        public Report_Dash_GUI()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SalesReport_GUI rpt = new SalesReport_GUI();
            rpt.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PurchaseReport_GUI pur = new PurchaseReport_GUI();
            pur.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SalesChart_GUI charts = new SalesChart_GUI();
            charts.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PurchaseChart_GUI ch = new PurchaseChart_GUI();
            ch.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MonthlySalesChart_GUI ch = new MonthlySalesChart_GUI();
            ch.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SalesReportMonthly_GUI rp = new SalesReportMonthly_GUI();
            rp.ShowDialog();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            AppoinmentMonthlyChart_GUI appoi = new AppoinmentMonthlyChart_GUI();
            appoi.ShowDialog();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            AppoinmentCancelChart_GUI ui = new AppoinmentCancelChart_GUI();
            ui.ShowDialog();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            AppoinmentsReport_GUI rpt = new AppoinmentsReport_GUI();
            rpt.ShowDialog();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            DrugPurchaseReport_GUI rpt=new DrugPurchaseReport_GUI();
            rpt.ShowDialog();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            DrugPurchaseChart_GUI ui = new DrugPurchaseChart_GUI();
            ui.ShowDialog();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            InventryRerport_GUI ui = new InventryRerport_GUI();
            ui.ShowDialog();
        }
    }
}
