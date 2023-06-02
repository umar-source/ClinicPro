using ClinicProWebApi.DAL;
using ClinicProWebApi.Models;
using ClinicProWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicProWebApi.Repositories.Implementations
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly ClinicProContext _dbContext;
        public DoctorRepository(ClinicProContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Doctor> DoctortsWithAppointments()
        {
            return _dbContext.Doctors.Where(p => p.Appointments.Any()).ToList();
     
        }
    }
}
