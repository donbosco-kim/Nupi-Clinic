using Nupi_Clinic.DataAccessLayer;
using Nupi_Clinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.Repositories
{
    public class AdminRepository
    {
        private readonly PatientDbContext _context;

        public AdminRepository()
        {
            _context = new PatientDbContext();
            _context.Database.EnsureCreated(); // Ensure the database is created
        }
        public IEnumerable<Admins> GetAllDoctor()
        {
            return _context.Admins.ToList();
        }

        public Admins? GetDoctor(int adminId)
        {
            return _context.Admins.Find(adminId);
        }
        public void AddAdmin(Admins admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }
        public void UpdateDoctor(Admins admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }
        public void DeleteDoctor(Admins selectedAdmin)
        {
            _context.Admins.Remove(selectedAdmin);
            _context.SaveChanges();
        }
    }
}
