using Nupi_Clinic.Model;
using Nupi_Clinic.Repositories;
using Nupi_Clinic.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Nupi_Clinic.View
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : UserControl
    {
        private readonly PatientRepository _patientRepository;
        public PatientView()
        {
            InitializeComponent();
            _patientRepository = new PatientRepository();

            // Load patients into the DataGrid when the window is initialized
            RefreshDataGrid();
        }
        public void RefreshDataGrid()
        {
            // Set the ItemsSource to the list of patients from the repository
            myDataGrid.ItemsSource = _patientRepository.GetAllPatients().ToList();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (int.TryParse(searchBar.Text, out int patientId))
            {
                Patients? existingPatient = _patientRepository.GetPatient(patientId);

                if (existingPatient != null)
                {
                    // Update patient details (replace the values with actual data)
                    existingPatient.FirstName = "UpdatedFirstName";
                    existingPatient.MiddleName = "UpdatedMiddleName";
                    existingPatient.LastName = "UpdatedLastName";
                    existingPatient.Birthdate = DateTime.Parse("1990-02-02");
                    existingPatient.Gender = "Female";
                    existingPatient.PhoneNumber = "987-654-3210";
                    existingPatient.Address = "456 Second St";

                    _patientRepository.UpdatePatient(existingPatient);

                    // Refresh or update UI as needed
                }
                else
                {
                    MessageBox.Show("Patient not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid patient ID.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Assume you have a TextBox named patientIdTextBox for entering patient ID
            if (int.TryParse(searchBar.Text, out int patientId))
            {
                _patientRepository.DeletePatient(patientId);

                // Refresh DataGrid after deleting a patient
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Invalid patient ID.");
            }
        }
    }
}
