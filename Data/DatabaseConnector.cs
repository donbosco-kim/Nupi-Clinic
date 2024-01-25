using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nupi_Clinic.Data
{
    internal class DatabaseConnector
    {
        private readonly String? connectionString;

        public DatabaseConnector(string? connectionString)
        {
            this.connectionString = connectionString;
        }

        private MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql Connection! \n" + ex.Message, "Error");
            }

            return connection;
        }
        private void CloseConnection(MySqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public DataTable ExecuteQuery(string query, MySqlParameter[] param)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using MySqlConnection connection = OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddRange(param);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                //DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable;

        }
    }
}
