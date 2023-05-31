using ClinicProWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicProWebApi.DAL
{
    public class ClinicProContext : DbContext
    {
        public ClinicProContext(DbContextOptions<ClinicProContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
