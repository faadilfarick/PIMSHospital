using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using ThePIMS_Hospital.DAL;

namespace ThePIMS_Hospital.GUI.Prescription
{
    /// <summary>
    /// Interaction logic for Presc_All.xaml
    /// </summary>
    public partial class Presc_All : Window
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Presc_All()
        {
            InitializeComponent();
        }
    }
}
