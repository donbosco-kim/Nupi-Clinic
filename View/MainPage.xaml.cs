﻿using Nupi_Clinic.Data;
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

namespace Nupi_Clinic.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void View_Appointment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Patient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Schedule_Appointment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            DBAdmin dBAdmin = new DBAdmin();
            dBAdmin.Logout();
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
