using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePIMS_Hospital.DAL;

namespace ThePIMS_Hospital.BIZ
{
    class Appoinment_Report
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public int Count { get; set; }


        public Appoinment_Report() { }

        public Appoinment_Report(string month, int count)
        {
            this.Month = month;
            this.Count = count;
        }
        public Appoinment_Report(string year,string month, int count)
        {
            this.Year = year;
            this.Month = month;
            this.Count = count;
        }


        public List<Appoinment_Report> apponmentsCount()
        {
            List<Appoinment_Report> pro = new List<Appoinment_Report>();
            string query = "appoinmentCountMonth";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                    string month = System.Globalization.CultureInfo.
                        CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(reader[1]));

                    pro.Add(new Appoinment_Report(reader[0].ToString() + "-" + month, Convert.ToInt32(reader[2])));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();

            return pro;
        }
        public List<Appoinment_Report> apponmentsCancelCount()
        {
            List<Appoinment_Report> pro = new List<Appoinment_Report>();
            string query = "appoinmentCancelCountMonth";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                    string month = System.Globalization.CultureInfo.
                        CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(reader[1]));

                    pro.Add(new Appoinment_Report(reader[0].ToString() + "-" + month, Convert.ToInt32(reader[2])));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();

            return pro;
        }


        public List<Appoinment_Report> apponmentsCountReport()
        {
            List<Appoinment_Report> pro = new List<Appoinment_Report>();
            string query = "appoinmentCountMonth";
            SqlDataReader reader = new SystemDAL().executeQuerys(query);

            while (reader.Read())
            {
                try
                {
                    string month = System.Globalization.CultureInfo.
                        CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(reader[1]));

                    pro.Add(new Appoinment_Report(reader[0].ToString() , month, Convert.ToInt32(reader[2])));

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
