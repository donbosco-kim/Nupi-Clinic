using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.Model
{
    public class Admin_Info
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Admin_Info(string firstname, string lastname, string username, string password)
        {
            FirstName = firstname;
            LastName = lastname;
            UserName = username;
            Password = password;

        }
    }
}
