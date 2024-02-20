using Nupi_Clinic.Command;
using Nupi_Clinic.Model;
using Nupi_Clinic.Repositories;
using Nupi_Clinic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nupi_Clinic.ViewModel
{
    public class AdminViewModel : BaseViewModel
    {
        //Fields
        private readonly AdminRepository? _repository;
        private Admin_Info? admin;
        //private string? userName;
        //private SecureString? password;

        public RelayCommand AddAdminCommand => new RelayCommand(execute => AddAdmin()); //need to check if admin already exist
        public RelayCommand LoginAdminCommand => new RelayCommand(execute => Login(), canExecute => CanLogin());
        public AdminViewModel()
        {
            _repository = new AdminRepository();
            admin = new Admin_Info();
        }
        //properties
        public string? AdminFirstName
        {
            get
            {
                return admin?.FirstName;
            }
            set
            {
                admin!.FirstName = value;
                OnPropertyChanged(nameof(AdminFirstName));
            }
        }
        public string? AdminLastName
        {
            get
            {
                return admin?.LastName;
            }
            set
            {

                admin!.FirstName = value;
                OnPropertyChanged(nameof(AdminLastName));
            }
        }
        public string? AdminUserName
        {
            get
            {
                return admin?.UserName;
            }
            set
            {
                admin!.UserName = value;
                OnPropertyChanged(nameof(AdminUserName));
            }
        }
        public string? AdminPassword
        {
            get
            {
                return admin?.Password;
            }
            set
            {
                admin!.Password = value;
                OnPropertyChanged(nameof(AdminPassword));
            }
        }
        private string ComputeSha256Hash(string rawData)
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


        private void AddAdmin()
        {
            
            if (string.IsNullOrWhiteSpace(AdminFirstName) || string.IsNullOrWhiteSpace(AdminLastName) || string.IsNullOrWhiteSpace(AdminUserName) || string.IsNullOrWhiteSpace(AdminPassword))
            {
                MessageBox.Show("Please fill up all the fields.");
                //return;
            }
            else
            {
                string hashedPassword = ComputeSha256Hash(AdminPassword);
                Admin_Info newAdmin = new Admin_Info
                {
                    FirstName = AdminFirstName,
                    LastName = AdminLastName,
                    UserName = AdminUserName,
                    Password = hashedPassword
                };

                _repository?.AddAdmin(newAdmin);

                MessageBox.Show("Admin added successfully!");
            }     
        }
        private void Login()
        {
            string hashedPassword = ComputeSha256Hash(AdminPassword!);
            var isValidAdmin = _repository?.AuthenticateUser(new System.Net.NetworkCredential(AdminUserName, hashedPassword));
            if ((bool)isValidAdmin!)
            {
                //direct to MainPage view
                MainPage main = new MainPage();
                main.Show();
                MainWindow window = new MainWindow(); 
                window.Close();
            }
            else
            {
                MessageBox.Show("Incorrect UserName or Password");
            }
        }
        private bool CanLogin()
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(AdminUserName) || AdminPassword == null)
                validData = false;
            else
                validData = true;
            return validData;
        }
        
    }
}
