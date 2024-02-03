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

        public PatientViewModel(string connectionString)
        {
            connector = new DatabaseConnector(connectionString);
            LoadPatients();
        }

        private async void LoadPatients()
        {
            try
            {
                string query = "SELECT * FROM ClinicDB.Patients";
                DataTable dataTable = await connector.ExecuteQueryAsync(query);
                Patients = ConvertDataTableToObservableCollection(dataTable);
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

        private ObservableCollection<Patient> ConvertDataTableToObservableCollection(DataTable dataTable)
        {
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

            foreach (DataRow row in dataTable.Rows)
            {
                // Assuming your columns have the appropriate names; adjust as needed
                string firstName = row["FirstName"].ToString();
                string middleName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();
                DateTime birthdate = Convert.ToDateTime(row["Birthdate"]);
                string gender = row["Gender"].ToString();
                string phoneNumber = row["PhoneNumber"].ToString();
                string address = row["Address"].ToString();

                // Create a new Patient object and add it to the ObservableCollection
                Patient patient = new Patient(firstName, middleName, lastName, birthdate, gender, phoneNumber, address);
                patients.Add(patient);
            }

            return patients;
        }

    }
}
