using Nupi_Clinic.DataAccessLayer;
using Nupi_Clinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.Repositories
{
    public class DoctorRepository
    {
        private readonly PatientDbContext _context;

        public DoctorRepository()
        {
            _context = new PatientDbContext();
            _context.Database.EnsureCreated(); // Ensure the database is created
        }
        public IEnumerable<Doctors> GetAllDoctor()
        {
            return _context.Doctors.ToList();
        }
        
        public Doctors? GetDoctor(int doctorId)
        {
            return _context.Doctors.Find(doctorId);
        }
        public void AddDoctor(Doctors patient)
        {
            _context.Doctors.Add(patient);
            _context.SaveChanges();
        }
        public void UpdateDoctor(Doctors doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }
        public void DeleteDoctor(Doctors selectedDoctor)
        {
            _context.Doctors.Remove(selectedDoctor);
            _context.SaveChanges();
        }

        //public void DeleteDoctor(int doctorId)
        //{
        //    var doctor = _context.Doctors.Find(doctorId);
        //    if (doctor != null)
        //    {
        //        _context.Doctors.Remove(doctor);
        //        _context.SaveChanges();
        //    }
        //}
    }
}
