﻿using Microsoft.EntityFrameworkCore;
using Nupi_Clinic.Model;
using System;


namespace Nupi_Clinic.DataAccessLayer
{
    public class PatientDbContext : DbContext
    {
        public DbSet<Admin_Info> Admins { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patients>().HasKey(p => p.PatientID);
            modelBuilder.Entity<Patients>().ToTable("Patients", schema: "ClinicDB");
            modelBuilder.Entity<Doctors>().HasKey(p => p.DoctorID);
            modelBuilder.Entity<Doctors>().ToTable("Doctors", schema: "ClinicDB");
            modelBuilder.Entity<Admin_Info>().HasKey(p => p.AdminID);
            modelBuilder.Entity<Admin_Info>().ToTable("Admins", schema: "ClinicDB");
            modelBuilder.Entity<Appointments>().HasKey(p => p.AppointmentID);
            modelBuilder.Entity<Appointments>().ToTable("Appointments", schema: "ClinicDB");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your database connection here
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-9IQ6CR4;Initial Catalog=NupiClinicDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;");
        }
    }
}
