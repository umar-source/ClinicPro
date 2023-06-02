using ClinicProWebApi.Models;
using System.Collections;

namespace ClinicProWebApi.Repositories.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {

        public IEnumerable<Department> DepartmentsWithHighestPatient();
    }
}
