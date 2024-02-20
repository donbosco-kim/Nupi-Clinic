using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace Nupi_Clinic.Data
{
    //Unused class
    internal class DatabaseConnector
    {
        private readonly string connectionString;

        public DatabaseConnector()
        {
            // Update the connection string to point to your SQL Server database
            connectionString = ConfigurationManager.ConnectionStrings["NupiDB"].ConnectionString;
        }
        //public string ConnectionString { get { return connectionString; } }

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

        //public void CloseConnection(SqlConnection connection)
        //{
        //    if (connection.State == ConnectionState.Open)
        //    {
        //        connection.Close();
        //    }
        //}

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

        internal async Task<DataTable> ExecuteQueryAsync(string query)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            await Task.Run(() => adapter.Fill(dataTable));

                            return dataTable;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Use Dispatcher to show a MessageBox in a WPF application
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("Error: " + ex.Message);
                });

                throw; // Re-throw the exception after handling/logging
            }
        }


    }
}
