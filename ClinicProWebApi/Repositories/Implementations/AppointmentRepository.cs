using ClinicProWebApi.DAL;
using ClinicProWebApi.Models;
using ClinicProWebApi.Repositories.Interfaces;

namespace ClinicProWebApi.Repositories.Implementations
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ClinicProContext dbContext) : base(dbContext)
        {
        }
    }
}
