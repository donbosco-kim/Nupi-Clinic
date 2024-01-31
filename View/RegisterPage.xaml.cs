using Nupi_Clinic.Data;
using Nupi_Clinic.Model;
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
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void submit_button_click(object sender, RoutedEventArgs e)
        {
            if (password.Password != confirmpassword.Password)
            {

                MessageBox.Show("Password doesn't match");
            }
            else if (admin_first_name.Text == string.Empty || admin_last_name.Text == string.Empty || user_name.Text == string.Empty || password.Password == string.Empty || password.Password == string.Empty)
            {
                MessageBox.Show("Pls Fill Up All The Fields");
            }

            else
            {
                DBAdmin newAdmin = new DBAdmin();
                Admin_Info? add = new(admin_first_name.Text.Trim(), admin_last_name.Text.Trim(), user_name.Text.Trim(), password.Password.Trim());
                newAdmin.AddAdmin(add);
                this.Close();
            }
        }

        private void reset_button_click(object sender, RoutedEventArgs e)
        {
            admin_first_name.Text = string.Empty;
            admin_last_name.Text = string.Empty;
            user_name.Text = string.Empty;
            password.Password = string.Empty;
            confirmpassword.Password = string.Empty;
        }

        private void cancel_button_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
