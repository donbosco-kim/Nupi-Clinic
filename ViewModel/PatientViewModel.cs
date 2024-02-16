using MySql.Data.MySqlClient;
using Nupi_Clinic.Command;
using Nupi_Clinic.Data;
using Nupi_Clinic.DataAccessLayer;
using Nupi_Clinic.Model;
using Nupi_Clinic.Repositories;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;


namespace Nupi_Clinic.ViewModel
{
    public class PatientViewModel : BaseViewModel
    {
        private readonly PatientRepository _repository;
        private ObservableCollection<Patients> _patient;
        private Patients selectedPatient;
        private int patientId;

        public RelayCommand AddPatientCommand => new RelayCommand(execute => AddPatient());
        public RelayCommand FindPatientCommand => new RelayCommand(execute => GetPatientById(), canExecute => PatientId > 0);
        public RelayCommand UpdatePatientCommand => new RelayCommand(execute => UpdatePatient());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeletePatient(), canExecute => SelectedPatient != null);
        public PatientViewModel()
        {
            _repository = new PatientRepository(); // Initialize _repository 
            _patient = new ObservableCollection<Patients>();
            selectedPatient = new Patients(); // this is needed to initialize properties that bind with text boxes
            LoadPatients();
            PatientBirthdate = DateTime.Now;
        }

        public ObservableCollection<Patients> Patients
        {
            get { return _patient; }
            set
            {
                if (_patient != value)
                {
                    _patient = value;
                    OnPropertyChanged(nameof(Patients));
                }
            }
        }

        public Patients SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }


        //Properties to bind with TextBoxes
        //Setting below properties solve the issue of Patient data not displaying in the textboxes in UpdatePatientView
        //add OnPropertyChanged in all the properties in PatientViewModel to reflect changes in the UI when user update Patient data.
        public int PatientId
        {
            get { return patientId; }
            set
            {
                if (patientId != value)
                {
                    patientId = value;
                    OnPropertyChanged(nameof(PatientId));
                }
            }
        }
        public string? PatientFirstName
        {
            get { return selectedPatient.FirstName; }
            set
            {
                if (selectedPatient.FirstName != value)
                {
                    selectedPatient.FirstName = value;
                    OnPropertyChanged(nameof(PatientFirstName));
                    OnPropertyChanged(nameof(selectedPatient));
                }
            }
        }

        public string? PatientMiddleName
        {
            get { return selectedPatient.MiddleName; }
            set
            {
                if (selectedPatient.MiddleName != value)
                {
                    selectedPatient.MiddleName = value;
                    OnPropertyChanged(nameof(PatientMiddleName));
                    OnPropertyChanged(nameof(selectedPatient));
                }
            }
        }

        public string? PatientLastName
        {
            get { return selectedPatient.LastName; }
            set
            {
                if (selectedPatient.LastName != value)
                {
                    selectedPatient.LastName = value;
                    OnPropertyChanged(nameof(PatientLastName));
                    OnPropertyChanged(nameof(selectedPatient));
                }
            }
        }

        public DateTime? PatientBirthdate
        {
            get { return selectedPatient.Birthdate; }
            set
            {
                if (selectedPatient.Birthdate != value)
                {
                    selectedPatient.Birthdate = (DateTime)value!;
                    OnPropertyChanged(nameof(PatientBirthdate));
                    OnPropertyChanged(nameof(selectedPatient)); // Notify UI about the change in selectedPatient
                }
            }
        }

        public string? PatientGender
        {
            get { return selectedPatient.Gender; }
            set
            {
                if (selectedPatient.Gender != value)
                {
                    selectedPatient.Gender = value;
                    OnPropertyChanged(nameof(PatientGender));
                    OnPropertyChanged(nameof(selectedPatient));
                }
            }
        }

        public string? PatientPhoneNumber
        {
            get { return selectedPatient.PhoneNumber; }
            set
            {
                if (selectedPatient.PhoneNumber != value)
                {
                    selectedPatient.PhoneNumber = value;
                    OnPropertyChanged(nameof(PatientPhoneNumber));
                    OnPropertyChanged(nameof(selectedPatient));
                }
            }
        }

        public string? PatientAddress
        {
            get { return selectedPatient.Address; }
            set
            {
                if (selectedPatient.Address != value)
                {
                    selectedPatient.Address = value;
                    OnPropertyChanged(nameof(PatientAddress));
                    OnPropertyChanged(nameof(selectedPatient));
                }
            }
        }


        // CRUD operations
        private void LoadPatients()
        {
            // Assuming GetAllPatients returns IEnumerable<Patients> from the repository
            var patients = _repository.GetAllPatients();

            // Convert IEnumerable<Patients> to ObservableCollection<Patients>
            Patients = new ObservableCollection<Patients>(patients);
        }
        private void AddPatient()
        {
            if (string.IsNullOrWhiteSpace(PatientFirstName) || string.IsNullOrWhiteSpace(PatientMiddleName) || string.IsNullOrWhiteSpace(PatientLastName) ||
                string.IsNullOrWhiteSpace(PatientGender) || string.IsNullOrWhiteSpace(PatientPhoneNumber) || string.IsNullOrWhiteSpace(PatientAddress))
            {
                MessageBox.Show("Please fill up all the fields.");
                return;
            }

            // Validate and parse the Birthdate
            if (PatientBirthdate.HasValue)
            {
                Patients newPatient = new Patients
                {
                    FirstName = PatientFirstName,
                    MiddleName = PatientMiddleName,
                    LastName = PatientLastName,
                    Birthdate = PatientBirthdate.Value,
                    Gender = PatientGender,
                    PhoneNumber = PatientPhoneNumber,
                    Address = PatientAddress,
                };

                _repository.AddPatient(newPatient);
                Patients.Add(newPatient); // Add to the ObservableCollection
                MessageBox.Show("Patient added successfully!");
            }
            else
            {
                MessageBox.Show("Invalid birthdate format. Please enter a valid date.");
            }
        }
        private void GetPatientById()
        {
            Patients? foundPatient = _repository.GetPatient(PatientId);

            if (foundPatient != null)
            {
                // Fill textboxes with the found patient's data
                //PatientId = foundPatient.PatientID;
                PatientFirstName = foundPatient.FirstName;
                PatientMiddleName = foundPatient.MiddleName;
                PatientLastName = foundPatient.LastName;
                PatientBirthdate = foundPatient.Birthdate;
                PatientGender = foundPatient.Gender;
                PatientPhoneNumber = foundPatient.PhoneNumber;
                PatientAddress = foundPatient.Address;
            }
            else
            {
                // Clear properties if patient is not found
                PatientFirstName = null;
                PatientMiddleName = null;
                PatientLastName = null;
                PatientBirthdate = null;
                PatientGender = null;
                PatientPhoneNumber = null;
                PatientAddress = null;

                MessageBox.Show("Patient not found.");
            }
        }

        private void UpdatePatient()
        {
            try
            {
                Patients? existingPatient = _repository.GetPatient(PatientId);
                if (existingPatient != null && PatientBirthdate.HasValue)
                {
                    existingPatient.FirstName = PatientFirstName;
                    existingPatient.MiddleName = PatientMiddleName;
                    existingPatient.LastName = PatientLastName;
                    existingPatient.Birthdate = PatientBirthdate.Value;
                    existingPatient.Gender = PatientGender;
                    existingPatient.PhoneNumber = PatientPhoneNumber;
                    existingPatient.Address = PatientAddress;

                    _repository.UpdatePatient(existingPatient);
                    MessageBox.Show("Updated Patient successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update Patient.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void DeletePatient()
        {
            _repository.DeletePatient(SelectedPatient);
            Patients.Remove(SelectedPatient);
        }
    }
}
