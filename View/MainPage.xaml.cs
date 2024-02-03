using Nupi_Clinic.Data;
using Nupi_Clinic.Model;
using Nupi_Clinic.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
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
        private readonly string connectionString;
        private readonly DatabaseConnector connector;
        public MainPage(string connectionString)
        {
            InitializeComponent();
            connector = new DatabaseConnector(connectionString);
            this.connectionString = connectionString;

        }

        private void View_Appointment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Patient_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new AddPatientView(connectionString);
        }

        private void Schedule_Appointment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            DBAdmin dBAdmin = new DBAdmin(connectionString);
            dBAdmin.Logout();
            this.Close();
        }
    }
}
