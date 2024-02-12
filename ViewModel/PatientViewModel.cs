using MySql.Data.MySqlClient;
using Nupi_Clinic.Command;
using Nupi_Clinic.Data;
using Nupi_Clinic.DataAccessLayer;
using Nupi_Clinic.Model;
using Nupi_Clinic.Repositories;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;


namespace Nupi_Clinic.ViewModel
{
    public class PatientViewModel : BaseViewModel
    {
        private readonly PatientRepository _repository;
        private Patients _patient;
        public RelayCommand AddPatientCommand => new RelayCommand(execute => AddPatient());
        //public RelayCommand ViewAllPatientCommand => new RelayCommand(execute => AllPatients());
        public RelayCommand UpdatePatientCommand => new RelayCommand(execute => UpdatePatient());
        //public RelayCommand DeleteCommand => new RelayCommand(execute => DeletePatient(selectedPatient), canExecute => SelectedPatient != null);
        public PatientViewModel()
        {
            _repository = new PatientRepository();
            _patient = new Patients();
            PatientBirthdate = DateTime.Now;
        }
        
        public Patients SelectedPatient
        {
            get { return _patient; }
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        //Properties to bind with TextBoxes
        public string? PatientFirstName
        {
            get { return _patient.FirstName; }
            set
            {
                if (_patient.FirstName != value)
                {
                    _patient.FirstName = value;
                    OnPropertyChanged(nameof(PatientFirstName));
                }
            }
        }

        public string? PatientMiddleName
        {
            get { return _patient.MiddleName; }
            set
            {
                if (_patient.MiddleName != value)
                {
                    _patient.MiddleName = value;
                    OnPropertyChanged(nameof(PatientMiddleName));
                }
            }
        }

        public string? PatientLastName
        {
            get { return _patient.LastName; }
            set
            {
                if (_patient.LastName != value)
                {
                    _patient.LastName = value;
                    OnPropertyChanged(nameof(PatientLastName));
                }
            }
        }

        public DateTime? PatientBirthdate
        {
            get { return _patient.Birthdate; }
            set
            {
                if (_patient.Birthdate != value)
                {
                    _patient.Birthdate = (DateTime)value!;
                    OnPropertyChanged(nameof(PatientBirthdate));
                }
            }
        }

        public string? PatientGender
        {
            get { return _patient.Gender; }
            set
            {
                if (_patient.Gender != value)
                {
                    _patient.Gender = value;
                    OnPropertyChanged(nameof(PatientGender));
                }
            }
        }

        public string? PatientPhoneNumber
        {
            get { return _patient.PhoneNumber; }
            set
            {
                if (_patient.PhoneNumber != value)
                {
                    _patient.PhoneNumber = value;
                    OnPropertyChanged(nameof(PatientPhoneNumber));
                }
            }
        }

        public string? PatientAddress
        {
            get { return _patient.Address; }
            set
            {
                if (_patient.Address != value)
                {
                    _patient.Address = value;
                    OnPropertyChanged(nameof(PatientAddress));
                }
            }
        }

        // CRUD operations
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
                MessageBox.Show("Patient added successfully!");
            }
            else
            {
                MessageBox.Show("Invalid birthdate format. Please enter a valid date.");
            }
        }



        public IEnumerable<Patients> GetAllPatients()
        {
            return _repository.GetAllPatients();
        }

        private Patients? GetPatient(int patientId)
        {
            return _repository.GetPatient(patientId);
        }

        private void UpdatePatient()
        {
            _repository.UpdatePatient(SelectedPatient);
        }

        private void DeletePatient(Patients selectedPatient)
        {
            _repository.DeletePatient(selectedPatient);
        }
    }
}
