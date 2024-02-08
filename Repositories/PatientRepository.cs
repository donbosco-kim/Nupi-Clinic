using Nupi_Clinic.DataAccessLayer;
using Nupi_Clinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.Repositories
{
    public class PatientRepository
    {
        private readonly PatientDbContext _context;

        public PatientRepository()
        {
            _context = new PatientDbContext();
            _context.Database.EnsureCreated(); // Ensure the database is created
        }

        public IEnumerable<Patients> GetAllPatients()
        {
            return _context.Patients.ToList();
        }
        public void AddPatient(Patients patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public Patients? GetPatient(int patientId)
        {
            return _context.Patients.Find(patientId);
        }

        public void UpdatePatient(Patients patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public void DeletePatient(int patientId)
        {
            var patient = _context.Patients.Find(patientId);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }
    }
}
