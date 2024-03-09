using Nupi_Clinic.Command;
using Nupi_Clinic.Model;
using Nupi_Clinic.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nupi_Clinic.ViewModel
{
    public class AppointmentViewModel : BaseViewModel
    {
        private readonly AppointmentRepository _repository;
        private readonly PatientRepository _prepository;
        private readonly DoctorRepository _drepository;
        private ObservableCollection<Appointments> appointments;
        private ObservableCollection<Doctors> _doctors;
        private ObservableCollection<Patients> _patients;
        private Appointments selectedAppointment;

        public AppointmentViewModel()
        {
            _repository = new AppointmentRepository();
            appointments = new ObservableCollection<Appointments>();
            selectedAppointment = new Appointments();
            _drepository = new DoctorRepository();
            _prepository = new PatientRepository();
            _doctors = new ObservableCollection<Doctors>();
            _patients = new ObservableCollection<Patients>();
            LoadAppointments();
            LoadDoctors();
            LoadPatients();
            Appointmentdate = DateTime.Now;
        }
        public RelayCommand ScheduleAppointmentCommand => new RelayCommand(execute => ScheduleAppointment());
        public ObservableCollection<Appointments> Appointments
        {
            get { return appointments; }
            set
            {
                if (appointments != value)
                {
                    appointments = value;
                    OnPropertyChanged(nameof(Appointments));
                }
            }
        }
        public ObservableCollection<Doctors> Doctors
        {
            get { return _doctors; }
            set
            {
                if (_doctors != value)
                {
                    _doctors = value;
                    OnPropertyChanged(nameof(Doctors));
                }
            }
        }

        public ObservableCollection<Patients> Patients
        {
            get { return _patients; }
            set
            {
                if (_patients != value)
                {
                    _patients = value;
                    OnPropertyChanged(nameof(Patients));
                }
            }
        }
        public Appointments SelectedAppointment
        {
            get { return selectedAppointment; }
            set
            {
                selectedAppointment = value;
                OnPropertyChanged(nameof(SelectedAppointment));
            }
        }
        public int DoctorId
        {
            get { return selectedAppointment.DoctorID; }
            set
            {
                if (selectedAppointment.DoctorID != value)
                {
                    selectedAppointment.DoctorID = value;
                    OnPropertyChanged(nameof(DoctorId));

                }
            }
        }
        public int PatientId
        {
            get { return selectedAppointment.PatientID; }
            set
            {
                if (selectedAppointment.PatientID != value)
                {
                    selectedAppointment.PatientID = value;
                    OnPropertyChanged(nameof(PatientId));
                }
            }
        }
        public DateTime? Appointmentdate
        {
            get { return selectedAppointment.AppointmentDate; }
            set
            {

                selectedAppointment.AppointmentDate = (DateTime)value!;
                OnPropertyChanged(nameof(Appointmentdate));
            }
        }
        public string? Doctorname
        {
            get { return selectedAppointment.DoctorName; }
            set
            {
                selectedAppointment.DoctorName = value;
                OnPropertyChanged(nameof(Doctorname));
            }
        }
        public string? Patientname
        {
            get { return selectedAppointment.PatientName; }
            set
            {
                selectedAppointment.PatientName = value;
                OnPropertyChanged(nameof(Patientname));
            }
        }

        private void LoadAppointments()
        {
            var appointments = _repository.GetAppointmentsWithDetails();
            Appointments = new ObservableCollection<Appointments>(appointments);
        }
        //to fill combobox
        private void LoadDoctors()
        {
            var doctorList = _drepository.GetAllDoctor();
            Doctors = new ObservableCollection<Doctors>(doctorList);
        }
        //to fill combobox
        private void LoadPatients()
        {
            var patientList = _prepository.GetAllPatients();
            Patients = new ObservableCollection<Patients>(patientList);
        }
        private void ScheduleAppointment()
        {
            if (string.IsNullOrWhiteSpace(Doctorname) || string.IsNullOrWhiteSpace(Patientname))
            {
                MessageBox.Show("Please fill up all the fields.");
                return;
            }

            // Check if Appointmentdate is selected
            if (Appointmentdate == null)
            {
                MessageBox.Show("Please select appointment date.");
                return;
            }

            // Create a new Appointment object
            Appointments newAppointment = new Appointments
            {
                //hardcoded for now
                AdminID = 1,
                DoctorID = DoctorId,
                PatientID = PatientId,
                DoctorName = Doctorname,
                PatientName = Patientname,
                AppointmentDate = Appointmentdate.Value
            };

            // Add the new appointment to the database
            _repository.AddAppointment(newAppointment);
            Appointments.Add(newAppointment);

            // Clear the selected values
            Doctorname = "";
            Patientname = "";
            Appointmentdate = DateTime.Now;

            MessageBox.Show("Appointment scheduled successfully!");
        }
    }
}
