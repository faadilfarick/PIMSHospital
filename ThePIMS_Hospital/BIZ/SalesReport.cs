using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePIMS_Hospital.DAL;

namespace ThePIMS_Hospital.BIZ
{
    class SalesReport
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TrackNo { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }
        public string Date2 { get; set; }
        public decimal Price { get; set; }

        public string Year { get; set; }
        public string Month { get; set; }


        public SalesReport() { }

        public SalesReport(string date)
        {
            this.Date = date;
        }
        public SalesReport(string date, decimal price)
        {
            this.Date = date;
            this.Price = price;
        }
        public SalesReport(string year, string  month,decimal tot)
        {
            this.Year = year;
            this.Month = month;
            this.Price = tot;
        }
        public SalesReport(string date, string date2)
        {
            this.Date = date;
            this.Date2 = date2;
        }
        public SalesReport(int id, string name, int TrackNo, int qty, decimal price)
        {
            this.ID = id;
            this.Name = name;
            this.TrackNo = TrackNo;
            this.Quantity = qty;
            this.Price = price;
        }



        public List<SalesReport> salesRpt()
        {
            List<SalesReport> pro = new List<SalesReport>();
            string query = "GetSalesReportDay '" + Date + "'";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                    pro.Add(new SalesReport(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToInt32(reader[2]), Convert.ToInt32(reader[3]), Convert.ToDecimal(reader[4])));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();

            return pro;
        }


        public SalesReport rptSum()
        {
            SalesReport rpt = new SalesReport();

            string query = "GetSumSalesReportDay '" + Date + "'";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);
            if (reader.Read())
            {
                try
                {
                    rpt.Price = Convert.ToDecimal(reader[0]);
                }
                catch (Exception)
                {

                    rpt.Price = 0;
                }

            }
            return rpt;
        }


        public List<SalesReport> salesRptChart()
        {
            List<SalesReport> pro = new List<SalesReport>();
            string query = "GetSalesReportDayChart '" + Date + "','" + Date2 + "'";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                    pro.Add(new SalesReport(Convert.ToDateTime(reader[0]).ToShortDateString(), Convert.ToDecimal(reader[1])));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();

            return pro;
        }

        public List<SalesReport> salesRptMonthly()
        {
            List<SalesReport> pro = new List<SalesReport>();
            string query = "monthlySales";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                    string month=System.Globalization.CultureInfo.
                        CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(reader[1]));

                    pro.Add(new SalesReport(reader[0].ToString()+" "+month, Convert.ToDecimal(reader[2])));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();

            return pro;
        }

        public List<SalesReport> salesRptMonthlyRpt()
        {
            List<SalesReport> pro = new List<SalesReport>();
            string query = "monthlySales";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                    string month = System.Globalization.CultureInfo.
                        CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(reader[1]));

                    pro.Add(new SalesReport(reader[0].ToString() , month, Convert.ToDecimal(reader[2])));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();

            return pro;
        }

    }


}
