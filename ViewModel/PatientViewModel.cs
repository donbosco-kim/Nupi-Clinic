using Nupi_Clinic.Data;
using Nupi_Clinic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nupi_Clinic.ViewModel
{
    internal class PatientViewModel : BaseViewModel
    {
        private readonly DatabaseConnector _connector;

        private ObservableCollection<Patient> _patients;

        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }
            set
            {
                _patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        public PatientViewModel(DatabaseConnector connector)
        {
            _connector = connector;
            LoadPatients();
        }

        private async void LoadPatients()
        {
            try
            {
                string query = "SELECT * FROM ClinicDB.Patients";
                DataTable result = await _connector.ExecuteQueryAsync(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred!\n" + ex.Message, "Error");
            }
        }
        
    }
}
