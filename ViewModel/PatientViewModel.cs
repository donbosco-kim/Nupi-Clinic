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

        public RelayCommand AddPatientCommand => new RelayCommand(execute => AddPatient());
        public RelayCommand UpdatePatientCommand => new RelayCommand(execute => UpdatePatient());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeletePatient(), canExecute => SelectedPatient != null);
        public PatientViewModel()
        {
            _repository = new PatientRepository(); // Initialize _repository
            _patient = new ObservableCollection<Patients>();
            LoadPatients();

            //PatientBirthdate = DateTime.Now;
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
        public string? PatientFirstName { get; set; }
        public string? PatientMiddleName { get; set; }
        public string? PatientLastName { get; set; }
        public DateTime? PatientBirthdate { get; set; }
        public string? PatientGender { get; set; }
        public string? PatientPhoneNumber { get; set; }
        public string? PatientAddress { get; set; }


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


        //public IEnumerable<Patients> GetAllPatients()
        //{
        //    return _repository.GetAllPatients();
        //}
        private void UpdatePatient()
        {
            _repository.UpdatePatient(SelectedPatient);
        }

        //I want to delete patient by selecting it and click delete button.
        private void DeletePatient()
        {
            _repository.DeletePatient(SelectedPatient);
            Patients.Remove(SelectedPatient);
        }
    }
}
