using Nupi_Clinic.Data;
using Nupi_Clinic.Model;
using Nupi_Clinic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nupi_Clinic.View
{
    /// <summary>
    /// Interaction logic for AddPatientView.xaml
    /// </summary>
    public partial class AddPatientView : UserControl
    {
        public AddPatientView()
        {
            InitializeComponent();
           
        }

        private void Add_Patient_Click(object sender, RoutedEventArgs e)
        {
            // Initialize PatientViewModel with the DatabaseConnector instance
            PatientViewModel patientViewModel = new PatientViewModel();
            

            if (firstName.Text == string.Empty || middleName.Text == string.Empty || lastName.Text == string.Empty || birthDate.Text == string.Empty || genderComboBox.Text == string.Empty || phoneNumber.Text == string.Empty || address.Text == string.Empty)
            {
                MessageBox.Show("Pls Fill UP All The Fields");
            }

            else
            {
                DateTime birthdate = DateTime.Parse(birthDate.Text);
                Patient add = new Patient(firstName.Text.Trim(), middleName.Text.Trim(), lastName.Text.Trim(), birthdate, genderComboBox.Text.Trim(), phoneNumber.Text.Trim(), address.Text.Trim());
                patientViewModel.AddPatient(add);
            }
        }
    }
}
