using MySql.Data.MySqlClient;
using Nupi_Clinic.Model;
using System.Data.SqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using Nupi_Clinic.View;
using System.Reflection.PortableExecutable;

namespace Nupi_Clinic.Data
{
    internal class DBAdmin
    {
        private readonly DatabaseConnector connector;
        //private Admin_Info? currentAdmin;

        // Pass the connection string to the constructor of DBAdmin
        public DBAdmin(string connectionString)
        {
            // Instantiate the DatabaseConnector with the provided connection string
            connector = new DatabaseConnector(connectionString);
        }

        public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void AddAdmin(Admin_Info admin)
        {
            string query = "INSERT INTO ClinicDB.Admins VALUES(@firstName, @lastName, @userName, @Password)";
            string hashedPassword = ComputeSha256Hash(admin.Password);

            try
            {
                using (SqlConnection con = connector.OpenConnection())
                {
                    if (con.State == ConnectionState.Open)
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = admin.FirstName;
                            cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = admin.LastName;
                            cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = admin.UserName;
                            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = hashedPassword;

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Added Successfully.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Database connection is not open.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public bool Login(string username, string hashedPassword)
        {
            string sql = "SELECT Username, Password FROM ClinicDB.Admins WHERE UserName = @userName AND Password = @password";

            try
            {
                using (SqlConnection con = connector.OpenConnection())
                {
                    if (con.State == ConnectionState.Open)
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@userName", username);
                            cmd.Parameters.AddWithValue("@password", hashedPassword);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                return reader.Read();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Database connection is not open.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false; // Return false in case of an exception or other failure
        }
        public bool ConfirmLogout()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        public void Logout()
        {
            // Confirm the logout with the user
            if (ConfirmLogout())
            {
                // Perform any necessary actions to clear authentication-related data or session information
                // For example, clear the current admin's authentication-related data
                //ClearAdminAuthenticationData();

                // Display a message indicating successful logout
                MessageBox.Show("Logout successful.");
                // Redirect to a login screen or perform any other desired actions after logout
                MainWindow main = new MainWindow();
                main.Show();

            }
        }

        //private void ClearAdminAuthenticationData()
        //{
        //    // Here, set the current admin to null or clear its properties
        //    currentAdmin = null;
        //}
    }
}
