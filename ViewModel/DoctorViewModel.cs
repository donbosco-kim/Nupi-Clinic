using Nupi_Clinic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.ViewModel
{
    public class DoctorViewModel : BaseViewModel
    {
        private ObservableCollection<Doctors> doctors;
        private Doctors selectedDoctor;

        public DoctorViewModel()
        {

        }
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
        // CRUD operations
        private void LoadPatients()
        {
            // Assuming GetAllPatients returns IEnumerable<Patients> from the repository
            //var doctors = _repository.GetAllPatients();

            // Convert IEnumerable<Patients> to ObservableCollection<Patients>
            Doctors = new ObservableCollection<Doctors>(doctors);
        }
        private void AddDoctor()
        {
            
        }

        private void DeleteDoctor()
        {
            Doctors.Remove(selectedDoctor);
        }
        private void SaveDoctor()
        {
            //save tos sql database
        }
        private bool CanSave()
        {
            //is the database connected
            //does the user that logged in have permission to save
            return true;
        }
    }
}
