using MySql.Data.MySqlClient;
using Nupi_Clinic.Command;
using Nupi_Clinic.Data;
using Nupi_Clinic.Model;
using Nupi_Clinic.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nupi_Clinic.ViewModel
{
    internal class PatientViewModel : BaseViewModel
    {
        private readonly PatientRepository _repository;
        private Patients _patient;
        private Patients selectedPatient;

        public RelayCommand AddNewPatient => new RelayCommand(execute => AddPatient());
        public RelayCommand ViewAllPatientCommand => new RelayCommand(execute => AllPatients());
        public RelayCommand UpdatePatientCommand => new RelayCommand(execute => UpdatePatient());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeletePatient(selectedPatient), canExecute => SelectedPatient != null);
        public PatientViewModel()
        {
            _repository = new PatientRepository();
            _patient = new Patients();
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
        public string? FirstName
        {
            get { return _patient.FirstName; }
            set
            {
                if (_patient.FirstName != value)
                {
                    _patient.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string? MiddleName
        {
            get { return _patient.MiddleName; }
            set
            {
                if (_patient.MiddleName != value)
                {
                    _patient.MiddleName = value;
                    OnPropertyChanged(nameof(MiddleName));
                }
            }
        }

        public string? LastName
        {
            get { return _patient.LastName; }
            set
            {
                if (_patient.LastName != value)
                {
                    _patient.LastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public DateTime Birthdate
        {
            get { return _patient.Birthdate; }
            set
            {
                if (_patient.Birthdate != value)
                {
                    _patient.Birthdate = value;
                    OnPropertyChanged(nameof(Birthdate));
                }
            }
        }

        public string? Gender
        {
            get { return _patient.Gender; }
            set
            {
                if (_patient.Gender != value)
                {
                    _patient.Gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        public string? PhoneNumber
        {
            get { return _patient.PhoneNumber; }
            set
            {
                if (_patient.PhoneNumber != value)
                {
                    _patient.PhoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public string? Address
        {
            get { return _patient.Address; }
            set
            {
                if (_patient.Address != value)
                {
                    _patient.Address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        // CRUD operations
        private void AddPatient()
        {
            _repository.AddPatient(_patient);
        }
        private IEnumerable<Patients> AllPatients()
        {
            return _repository.GetAllPatients();
        }

        private Patients? GetPatient(int patientId)
        {
            return _repository.GetPatient(patientId);
        }

        private void UpdatePatient()
        {
            _repository.UpdatePatient(_patient);
        }

        private void DeletePatient(Patients selectedPatient)
        {
            _repository.DeletePatient(selectedPatient);
        }
    }
}
