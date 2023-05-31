using ClinicProWebApi.Repositories.Interfaces;

namespace ClinicProWebApi.Services
{
    public interface IUnitOfWork
    {
        public IAppointmentRepository AppointmentRepo { get; }
        public IPatientRepository PatientRepo { get; }
        public IDoctorRepository DoctorRepo { get; }
        public IDepartmentRepository DepartmentRepo { get; }

        void Commit();

        void Rollback();
    }
}
