using ClinicProWebApi.DAL;
using ClinicProWebApi.Models;
using ClinicProWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicProWebApi.Repositories.Implementations
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ClinicProContext dbContext) : base(dbContext)
        {
        }


      
    }
}
