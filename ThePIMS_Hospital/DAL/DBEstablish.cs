using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ThePIMS_Hospital.DAL
{
    class DBEstablish
    {
        public static string makeConnection()
        {
            string con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            return con;
        }
    }
}
