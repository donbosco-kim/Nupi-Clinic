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
            if (string.IsNullOrWhiteSpace(firstName.Text) || string.IsNullOrWhiteSpace(middleName.Text) || string.IsNullOrWhiteSpace(lastName.Text) ||
                string.IsNullOrWhiteSpace(birthDate.Text) || string.IsNullOrWhiteSpace(genderComboBox.Text) || string.IsNullOrWhiteSpace(phoneNumber.Text) ||
                string.IsNullOrWhiteSpace(address.Text))
            {
                MessageBox.Show("Please fill up all the fields.");
            }
            else
            {
                // Validate and parse the Birthdate
                if (DateTime.TryParse(birthDate.Text, out DateTime birthdate))
                {
                    // Create a new patient instance 
                    Patients newPatient = new Patients
                    {
                        FirstName = firstName.Text,
                        MiddleName = middleName.Text,
                        LastName = lastName.Text,
                        Birthdate = birthdate,
                        Gender = genderComboBox.Text,
                        PhoneNumber = phoneNumber.Text,
                        Address = address.Text,
                    };

                    // Add the new patient to the repository
                    _patientRepository.AddPatient(newPatient);

                    MessageBox.Show("Patient added successfully!");

                    // Refresh DataGrid after adding a patient
                    _patientView.RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("Invalid birthdate format. Please enter a valid date.");
                }
            }
        }

    }
}
