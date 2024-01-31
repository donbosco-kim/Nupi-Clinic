using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace Nupi_Clinic.Data
{
    internal class DatabaseConnector
    {
        private readonly string connectionString;

        public DatabaseConnector()
        {
            // Update the connection string to point to your SQL Server database
            this.connectionString = ConfigurationManager.ConnectionStrings["NupiDB"].ConnectionString;
        }

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Server Connection Error!\n" + ex.Message, "Error");
            }

            return connection;
        }

        private void CloseConnection(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = OpenConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }
}
