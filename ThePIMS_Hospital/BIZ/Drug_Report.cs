﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePIMS_Hospital.DAL;

namespace ThePIMS_Hospital.BIZ
{
    class Drug_Report
    {
        public int ID { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string DrugName { get; set; }
        public string Category { get; set; }
        public int Qty { get; set; }
        public decimal UnitSellingPrice { get; set; }
        public int Reorder { get; set; }
        public string Type { get; set; }
        public string Shelf { get; set; }
       



        public Drug_Report() { }

        public Drug_Report(int id)
        {
            this.ID = id;
        }
        public Drug_Report(string year, string month, string dName, string cat, int qty)
        {
            this.Year = year;
            this.Month = month;
            this.DrugName = dName;
            this.Category = cat;
            this.Qty = qty;
        }

        public Drug_Report(int id,string name,decimal price,string cata,int reorder,string dType,string shelf,int qty)
        {
            this.ID = id;
            this.DrugName = name;
            this.UnitSellingPrice = price;
            this.Category = cata;
            this.Reorder = reorder;
            this.Type = dType;
            this.Shelf = shelf;
            this.Qty = qty;
        }


        public List<Drug_Report> DrugPurchasedMontly()
        {
            List<Drug_Report> pro = new List<Drug_Report>();
            string query = "DrugqtyPurchasedForTheMonth '" + ID + "'";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                      string month=System.Globalization.CultureInfo.
                        CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(reader[1]));
                    pro.Add(new Drug_Report( reader[0].ToString(),month,reader[2].ToString(),reader[3].ToString(),Convert.ToInt32(reader[4])));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();

            return pro;
        }
        public List<Drug_Report> DrugPurchasedMontlyAll()
        {
            List<Drug_Report> pro = new List<Drug_Report>();
            string query = "DrugqtyPurchasedForTheMonthAll";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                    string month = System.Globalization.CultureInfo.
                      CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(reader[1]));
                    pro.Add(new Drug_Report(reader[0].ToString(), month, reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4])));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();

            return pro;
        }


        public List<Drug_Report> DrugInvRpt()
        {
            List<Drug_Report> pro = new List<Drug_Report>();
            string query = "drugInventryReportData";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {

                    pro.Add(new Drug_Report(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToDecimal(reader[2]), reader[3].ToString(), Convert.ToInt32(reader[4]), reader[5].ToString(), reader[6].ToString(), Convert.ToInt32(reader[7])));

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
