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
using ThePIMS_Hospital.GUI.Doctor;
using ThePIMS_Hospital.GUI.Patient;

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
    }
}
