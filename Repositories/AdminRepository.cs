using Nupi_Clinic.DataAccessLayer;
using Nupi_Clinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public bool AuthenticateUser (NetworkCredential credential)
        {
            // Basic example: Check if a user with the provided credentials exists in the database
            var admin = _context.Admins.FirstOrDefault(a => a.UserName == credential.UserName && a.Password == credential.Password);

            // If an admin is found, authentication is successful
            bool validAdmin = admin != null;

            return validAdmin;
        }
        public IEnumerable<Admin_Info> GetAllAdmin()
        {
            return _context.Admins.ToList();
        }

        public Admin_Info? GetAdmin(int adminId)
        {
            return _context.Admins.Find(adminId);
        }
        public void AddAdmin(Admin_Info admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }
        public void UpdateAdmin(Admin_Info admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }
        public void DeleteAdmin(Admin_Info selectedAdmin)
        {
            _context.Admins.Remove(selectedAdmin);
            _context.SaveChanges();
        }
    }
}
