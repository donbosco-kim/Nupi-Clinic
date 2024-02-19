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
        public IEnumerable<Admin_Info> GetAllDoctor()
        {
            return _context.Admins.ToList();
        }

        public Admin_Info? GetDoctor(int adminId)
        {
            return _context.Admins.Find(adminId);
        }
        public void AddAdmin(Admin_Info admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }
        public void UpdateDoctor(Admin_Info admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }
        public void DeleteDoctor(Admin_Info selectedAdmin)
        {
            _context.Admins.Remove(selectedAdmin);
            _context.SaveChanges();
        }
    }
}
