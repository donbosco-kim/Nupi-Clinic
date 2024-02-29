using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.Model
{
    public class Appointments
    {
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime AppointmentDate { get; set; }
        
        public virtual Doctors? Doctors { get; set; }
        public virtual Patients? Patients { get; set; }
    }
}
