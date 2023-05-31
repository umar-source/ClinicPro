using ClinicProWebApi.DAL;
using ClinicProWebApi.Models;
using ClinicProWebApi.Repositories.Interfaces;

namespace ClinicProWebApi.Repositories.Implementations
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ClinicProContext dbContext) : base(dbContext)
        {
        }
    }
}
