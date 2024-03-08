using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.Model
{
    public class Doctors
    {
        public int DoctorID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Specialty { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Appointments> Appointments { get; set; }
    }
}
