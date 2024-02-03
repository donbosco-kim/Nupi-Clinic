using MySql.Data.MySqlClient;
using Nupi_Clinic.Data;
using Nupi_Clinic.Model;
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
        private readonly DatabaseConnector connector;
        private Patient _patient;

        public PatientViewModel(string connectionString)
        {
            _patient = new Patient();
            connector = new DatabaseConnector(connectionString);
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

        private async void LoadPatients()
        {
            try
            {
                string query = "SELECT * FROM ClinicDB.Patients";
                DataTable dataTable = await connector.ExecuteQueryAsync(query);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred!\n" + ex.Message, "Error");
            }
        }
        public void AddPatient(Patient patient)
        {
            
            string sql = "INSERT INTO ClinicDB.Patients VALUES(NULL, @firstName, @lastName, @birthDate, @gender, @phoneNumber)";
            SqlConnection con = connector.OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = patient.FirstName;
            cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = patient.LastName;
            cmd.Parameters.Add("@birthDate", SqlDbType.DateTime).Value = patient.Birthdate;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = patient.Gender;
            cmd.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = patient.PhoneNumber;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.");

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Patient not added sucessfully \n" + ex.Message);

            }
            con.Close();

        }

    }
}
