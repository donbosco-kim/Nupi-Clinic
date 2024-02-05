using Nupi_Clinic.Data;
using Nupi_Clinic.View;
using Nupi_Clinic.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;

namespace Nupi_Clinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DatabaseConnector connector;
        public MainWindow()
        {
            InitializeComponent();
            connector = new DatabaseConnector();
        }

        private void Login_button_click(object sender, RoutedEventArgs e)
        {
            
            DBAdmin dBAdmin = new DBAdmin();
            string hashedPassword = dBAdmin.ComputeSha256Hash(password.Password);

            if (dBAdmin.Login(user_name.Text, hashedPassword))
            {
                //direct to MainPage view
                MainPage main = new MainPage();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect UserName or Password");
            }
        }


        private void Register_button_click(object sender, RoutedEventArgs e)
        {
            RegisterPage win = new RegisterPage();
            win.Show();
        }

        private void Close_button_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}