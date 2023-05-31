using ClinicProWebApi.Models;
using ClinicProWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicProWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllAppointment()
        {
            var appointment = _unitOfWork.AppointmentRepo.GetAll();
            if (appointment == null)
            {
                return NoContent();
            }
            return Ok(appointment);
        }

        /*
          
        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(int id)
        {
        }

         */

        [HttpPost]
        public IActionResult CreateAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.AppointmentRepo.Add(appointment);
            _unitOfWork.Commit();
            CreatedAtAction("GetDepartment", new { id = appointment.AppointmentId }, appointment);

            return Ok(appointment);
        }



        [HttpGet("{Id}", Name = "AppointmentById")]
        public IActionResult AppointmentById(int Id)
        {
            var appointment = _unitOfWork.AppointmentRepo.GetById(Id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }


        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = _unitOfWork.AppointmentRepo.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            _unitOfWork.AppointmentRepo.Delete(appointment);
            _unitOfWork.Commit();
            return NoContent();
        }



        [HttpPut("{Id}")]
        public IActionResult UpdateAppointment(int Id, [FromBody] Appointment appointment)
        {

            var a = _unitOfWork.AppointmentRepo.GetById(Id);

            if (a == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update the properties of p with the values from the product object
            a.PatientName = appointment.PatientName;
            a.AppointmentDate = appointment.AppointmentDate;
            a.DoctorId = appointment.DoctorId;
            a.AppointmentType = appointment.AppointmentType;
            a.Reason = appointment.Reason;

            _unitOfWork.AppointmentRepo.Update(a);
            _unitOfWork.Commit();
            return Ok(a);
        }
    }
}
