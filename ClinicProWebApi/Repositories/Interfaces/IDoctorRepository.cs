﻿using ClinicProWebApi.Models;

namespace ClinicProWebApi.Repositories.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {

        public IEnumerable<Doctor> DoctortsWithAppointments();
    }
}
