using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.Model
{
    public class Appointments
    {
        public int AdminID { get; set; }
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? DoctorName { get; set; }
        public string? PatientName { get; set; }
    }
}
