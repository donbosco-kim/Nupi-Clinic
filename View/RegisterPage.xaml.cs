using Nupi_Clinic.Data;
using Nupi_Clinic.Model;
using Nupi_Clinic.ViewModel;
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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        private readonly MainWindow? _mainWindow;
        public RegisterPage()
        {
            InitializeComponent();
            AdminViewModel vm = new AdminViewModel(_mainWindow);
            DataContext = vm;

        }

        private void reset_button_click(object sender, RoutedEventArgs e)
        {
            //admin_first_name.Text = string.Empty;
            //admin_last_name.Text = string.Empty;
            //user_name.Text = string.Empty;
            //password.Password = string.Empty;
            //confirmpassword.Password = string.Empty;
        }

        private void cancel_button_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
