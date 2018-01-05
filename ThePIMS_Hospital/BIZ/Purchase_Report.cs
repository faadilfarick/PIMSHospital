using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePIMS_Hospital.DAL;

namespace ThePIMS_Hospital.BIZ
{
    class Purchase_Report
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public int ID { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }
        public string Date { get; set; }
        public string Date2 { get; set; }



        public Purchase_Report() { }
        public Purchase_Report(string date)
        {
            this.Date = date;
        }
        public Purchase_Report(string date,string date2)
        {
            this.Date = date;
            this.Date2 = date2;
        }
        public Purchase_Report(string date, int qty)
        {
            this.Date = date;
            this.Quantity = qty;
        }
        public Purchase_Report(string date, decimal price)
        {
            this.Date = date;
            this.Price = price;
        }

        public Purchase_Report(int id, string dname, int qty, string supp, decimal price)
        {
            this.ID = id;
            this.DrugName = dname;
            this.Quantity = qty;
            this.Supplier = supp;
            this.Price = price;
        }

        public List<Purchase_Report> purchaseRpt()
        {
            List<Purchase_Report> pro = new List<Purchase_Report>();
            string query = "GetPurchaseReportDay '" + Date + "'";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                    pro.Add(new Purchase_Report(Convert.ToInt32(reader[0]),reader[1].ToString(),Convert.ToInt32(reader[2]),reader[3].ToString(),0));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();

            return pro;
        }
        public List<Purchase_Report> purchaseRptChart()
        {
            List<Purchase_Report> pro = new List<Purchase_Report>();
            string query = "GetPurchaseReportChart '" + Date + "','" + Date2 + "'";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                    pro.Add(new Purchase_Report(Convert.ToDateTime( reader[0]).ToShortDateString()+" "+reader[2].ToString(),Convert.ToInt32(reader[1])));

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
