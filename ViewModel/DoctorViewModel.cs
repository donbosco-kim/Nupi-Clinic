using Nupi_Clinic.Command;
using Nupi_Clinic.Model;
using Nupi_Clinic.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nupi_Clinic.ViewModel
{
    public class DoctorViewModel : BaseViewModel
    {
        private readonly DoctorRepository _repository;
        private ObservableCollection<Doctors> doctors;
        private Doctors selectedDoctor;

        public DoctorViewModel()
        {
            _repository = new DoctorRepository();
            doctors = new ObservableCollection<Doctors>();
            selectedDoctor = new Doctors();
            LoadDoctors();
        }
        public RelayCommand AddDoctorCommand => new RelayCommand(execute => AddDoctor());
        public RelayCommand UpdateCommand => new RelayCommand(execute => UpdateDoctor());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteDoctor(), canExecute => SelectedDoctor != null);
        public ObservableCollection<Doctors> Doctors
        {
            get { return doctors; }
            set
            {
                if (doctors != value)
                {
                    doctors = value;
                    OnPropertyChanged(nameof(Doctors));
                }
            }
        }
        public Doctors SelectedDoctor
        {
            get { return selectedDoctor; }
            set
            {
                selectedDoctor = value;
                OnPropertyChanged(nameof(SelectedDoctor));
            }
        }
        public string? DoctorFirstName
        {
            get { return selectedDoctor.FirstName; }
            set
            {
                if (selectedDoctor.FirstName != value)
                {
                    selectedDoctor.FirstName = value;
                    OnPropertyChanged(nameof(DoctorFirstName));

                }
            }
        }
        public string? DoctorLastName
        {
            get { return selectedDoctor.LastName; }
            set
            {
                if (selectedDoctor.LastName != value)
                {
                    selectedDoctor.LastName = value;
                    OnPropertyChanged(nameof(DoctorLastName));

                }
            }
        }
        public string? DoctorSpecialty
        {
            get { return selectedDoctor.Specialty; }
            set
            {
                if (selectedDoctor.Specialty != value)
                {
                    selectedDoctor.Specialty = value;
                    OnPropertyChanged(nameof(DoctorSpecialty));

                }
            }
        }
        public string? DoctorPhoneNumber
        {
            get { return selectedDoctor.PhoneNumber; }
            set
            {
                if (selectedDoctor.PhoneNumber != value)
                {
                    selectedDoctor.PhoneNumber = value;
                    OnPropertyChanged(nameof(DoctorPhoneNumber));

                }
            }
        }

        // CRUD operations
        private void LoadDoctors()
        {
            // Assuming GetAllDoctor returns IEnumerable<Doctor> from the repository
            var doctors = _repository.GetAllDoctor();

            // Convert IEnumerable<Doctors> to ObservableCollection<Doctors>
            Doctors = new ObservableCollection<Doctors>(doctors);
        }
        private void AddDoctor()
        {
            if (string.IsNullOrWhiteSpace(DoctorFirstName) || string.IsNullOrWhiteSpace(DoctorLastName) || string.IsNullOrWhiteSpace(DoctorSpecialty) ||
                string.IsNullOrWhiteSpace(DoctorPhoneNumber))
            {
                MessageBox.Show("Please fill up all the fields.");
                return;
            }
            Doctors newDoctor = new Doctors
            {
                FirstName = DoctorFirstName,
                LastName = DoctorLastName,
                Specialty = DoctorSpecialty,
                PhoneNumber = DoctorPhoneNumber
            };
            _repository.AddDoctor(newDoctor);
            Doctors.Add(newDoctor);
            MessageBox.Show("Doctor added successfully!");
        }
        private void UpdateDoctor()
        {
            _repository.UpdateDoctor(selectedDoctor);
        }

        private void DeleteDoctor()
        {
            _repository.DeleteDoctor(SelectedDoctor);
            Doctors.Remove(selectedDoctor);
        }
        private bool CanSave()
        {
            //is the database connected
            //does the user that logged in have permission to save
            return true;
        }
    }
}
