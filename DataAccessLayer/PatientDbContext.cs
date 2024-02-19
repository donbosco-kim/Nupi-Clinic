using Microsoft.EntityFrameworkCore;
using Nupi_Clinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nupi_Clinic.DataAccessLayer
{
    public class PatientDbContext : DbContext
    {
        public DbSet<Admin_Info> Admins { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        //public  DbSet<Appointment> Appointment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patients>().HasKey(p => p.PatientID);
            modelBuilder.Entity<Patients>().ToTable("Patients", schema: "ClinicDB");
            modelBuilder.Entity<Doctors>().HasKey(p => p.DoctorID);
            modelBuilder.Entity<Doctors>().ToTable("Doctors", schema: "ClinicDB");
            modelBuilder.Entity<Admin_Info>().HasKey(p => p.AdminID);
            modelBuilder.Entity<Admin_Info>().ToTable("Admins", schema: "ClinicDB");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your database connection here
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-9IQ6CR4;Initial Catalog=NupiClinicDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;");
        }
    }
}
