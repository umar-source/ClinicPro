using ClinicProWebApi.DAL;
using ClinicProWebApi.Models;
using ClinicProWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ClinicProWebApi.Repositories.Implementations
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly ClinicProContext _dbContext;
        public DepartmentRepository(ClinicProContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Department> DepartmentsWithHighestPatient() {   
            
            var departmentWithHighestPatients = _dbContext.Departments.Where(x => x.DepartmentId == 1).Include(x => x.Patients);
            return departmentWithHighestPatients;   
            
        }

  

    }
}
