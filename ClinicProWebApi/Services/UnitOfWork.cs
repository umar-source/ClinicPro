using ClinicProWebApi.DAL;
using ClinicProWebApi.Repositories.Interfaces;

namespace ClinicProWebApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicProContext _dbContext;

        public UnitOfWork(
            ClinicProContext dbContext,
            IAppointmentRepository appointmentRepository,
              IDoctorRepository doctorRepository,
              IPatientRepository patientRepository,
              IDepartmentRepository departmentRepository
            )
        {
            _dbContext = dbContext;
            AppointmentRepo = appointmentRepository;
            PatientRepo = patientRepository;
            DoctorRepo = doctorRepository;
            DepartmentRepo = departmentRepository;
        }

      

        public IAppointmentRepository AppointmentRepo { get; private set; }

        public IPatientRepository PatientRepo { get; private set; }

        public IDoctorRepository DoctorRepo { get; private set; }

        public IDepartmentRepository DepartmentRepo { get; private set; }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }
    }
}
