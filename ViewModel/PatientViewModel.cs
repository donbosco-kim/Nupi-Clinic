﻿using MySql.Data.MySqlClient;
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

                selectedPatient.FirstName = value;
                OnPropertyChanged(nameof(PatientFirstName));


            }
        }

        public string? PatientMiddleName
        {
            get { return selectedPatient.MiddleName; }
            set
            {

                selectedPatient.MiddleName = value;
                OnPropertyChanged(nameof(PatientMiddleName));


            }
        }

        public string? PatientLastName
        {
            get { return selectedPatient.LastName; }
            set
            {

                selectedPatient.LastName = value;
                OnPropertyChanged(nameof(PatientLastName));


            }
        }

        public DateTime? PatientBirthdate
        {
            get { return selectedPatient.Birthdate; }
            set
            {

                selectedPatient.Birthdate = (DateTime)value!;
                OnPropertyChanged(nameof(PatientBirthdate));


            }
        }

        public string? PatientGender
        {
            get { return selectedPatient.Gender; }
            set
            {

                selectedPatient.Gender = value;
                OnPropertyChanged(nameof(PatientGender));


            }
        }

        public string? PatientPhoneNumber
        {
            get { return selectedPatient.PhoneNumber; }
            set
            {
                selectedPatient.PhoneNumber = value;
                OnPropertyChanged(nameof(PatientPhoneNumber));
            }
        }

        public string? PatientAddress
        {
            get { return selectedPatient.Address; }
            set
            {

                selectedPatient.Address = value;
                OnPropertyChanged(nameof(PatientAddress));
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

                PatientFirstName = "";
                PatientMiddleName = "";
                PatientLastName = "";
                PatientBirthdate = DateTime.Now;
                PatientGender = "";
                PatientPhoneNumber = "";
                PatientAddress = "";
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
            _repository.UpdatePatient(selectedPatient);
            MessageBox.Show("Patient updated successfully!");
            //clear properties after update
        }
        private void DeletePatient()
        {
            _repository.DeletePatient(SelectedPatient);
            Patients.Remove(SelectedPatient);
        }
    }
}
