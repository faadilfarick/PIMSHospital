﻿using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThePIMS_Hospital.GUI.Channel_DOC;
using ThePIMS_Hospital.GUI.Doctor;
using ThePIMS_Hospital.GUI.Drug;
using ThePIMS_Hospital.GUI.Patient;
//using ThePIMS_Hospital.GUI.Prescription;

namespace ThePIMS_Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Patient_Reg reg = new Patient_Reg();
            reg.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Doc_Reg reg = new Doc_Reg();
            reg.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Channel_Doc page = new Channel_Doc();
            page.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Presc_Add add = new Presc_Add();
            //add.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Drug_Add drug = new  Drug_Add();
            drug.ShowDialog();
        }
    }
}
