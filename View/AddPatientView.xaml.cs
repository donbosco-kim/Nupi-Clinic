using Nupi_Clinic.Data;
using Nupi_Clinic.Model;
using Nupi_Clinic.Repositories;
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
        private readonly PatientRepository _patientRepository;
        private readonly PatientView _patientView;
        public AddPatientView()
        {
            InitializeComponent();
            _patientRepository = new PatientRepository();
            _patientView = new PatientView();

        }

        private void Add_Patient_Click(object sender, RoutedEventArgs e)
        {
            if (firstName.Text == string.Empty || middleName.Text == string.Empty || lastName.Text == string.Empty || birthDate.Text == string.Empty || genderComboBox.Text == string.Empty || phoneNumber.Text == string.Empty || address.Text == string.Empty)
            {
                MessageBox.Show("Pls Fill UP All The Fields");
            }
            else
            {
                // Create a new patient instance (replace the values with actual data)
                Patients newPatient = new Patients
                {
                    FirstName = firstName.Text,
                    MiddleName = middleName.Text,
                    LastName = lastName.Text,
                    Birthdate = DateTime.Parse(birthDate.Text),
                    Gender = genderComboBox.Text,
                    PhoneNumber = phoneNumber.Text,
                    Address = address.Text, 
                };

                _patientRepository.AddPatient(newPatient);

                // Refresh DataGrid after adding a patient
                _patientView.RefreshDataGrid();

            }
        }
    }
}
