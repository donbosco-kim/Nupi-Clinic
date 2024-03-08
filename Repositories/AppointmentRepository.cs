using Microsoft.EntityFrameworkCore;
using Nupi_Clinic.DataAccessLayer;
using Nupi_Clinic.Model;


namespace Nupi_Clinic.Repositories
{
    public class AppointmentRepository
    {
        private readonly PatientDbContext _context;

        public AppointmentRepository()
        {
            _context = new PatientDbContext();
        }

        public Appointments? GetAppointmentById(int appointmentId)
        {
            return _context.Appointments.Find(appointmentId);
        }
        //This method join appointment, doctor and patient tables to display doctor and patient names if their name
        //matches their ids in appointment table
        public IEnumerable<Appointments> GetAppointmentsWithDetails()
        {
            var appointmentsWithDetails = from appointment in _context.Appointments
                                          join doctor in _context.Doctors on appointment.DoctorID equals doctor.DoctorID
                                          join patient in _context.Patients on appointment.PatientID equals patient.PatientID
                                          select new Appointments
                                          {
                                              AppointmentID = appointment.AppointmentID,
                                              DoctorName = $"{doctor.FirstName} {doctor.LastName}",
                                              PatientName = $"{patient.FirstName} {patient.LastName}",
                                              AppointmentDate = appointment.AppointmentDate
                                          };

            return appointmentsWithDetails.ToList();
        }


        public void AddAppointment(Appointments appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }
        public void UpdateAppointment(Appointments appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }
        public void DeleteAppointment(int appointmentId)
        {
            var appointment = _context.Appointments.Find(appointmentId);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }

    }
}
