using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.Model
{
    internal class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public Patient (string firstName, string lastName, DateTime birthdate, string gender, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }
    }
}
