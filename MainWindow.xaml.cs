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
using Nupi_Clinic.ViewModel;

namespace Nupi_Clinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            AdminViewModel vm = new AdminViewModel(this);
            DataContext = vm;
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