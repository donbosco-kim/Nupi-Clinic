﻿using MySql.Data.MySqlClient;
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

namespace Nupi_Clinic.Data
{
    internal class DBAdmin
    {
        private DatabaseConnector connector;

        // Pass the connection string to the constructor of DBAdmin
        public DBAdmin()
        {
            // Instantiate the DatabaseConnector with the provided connection string
            connector = new DatabaseConnector();
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
                            cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = admin.firstName;
                            cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = admin.lastName;
                            cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = admin.userName;
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
    }
}
