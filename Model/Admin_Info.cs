using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.Model
{
    internal class Admin_Info
    {
        public string firstName {  get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }

        public Admin_Info(string firstname, string lastname, string username, string password)
        {
            firstName = firstname;
            lastName = lastname;
            userName = username;
            Password = password;

        }
    }
}
