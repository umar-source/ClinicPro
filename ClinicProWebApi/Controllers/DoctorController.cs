using ClinicProWebApi.Models;
using ClinicProWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace ClinicProWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetAllDoctor()
        {
            var doctor = _unitOfWork.DoctorRepo.GetAll();
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        /*
          
        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(int id)
        {
        }

         */

        [HttpPost]
        public IActionResult CreateDoctor([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.DoctorRepo.Add(doctor);
            _unitOfWork.Commit();
            CreatedAtAction("GetDoctor", new { id = doctor.DoctorId }, doctor);

            return Ok(doctor);
        }



        [HttpGet("{Id}", Name = "DoctorById")]
        public IActionResult GetDoctorById(int Id)
        {
            var doctor = _unitOfWork.DoctorRepo.GetById(Id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }


        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _unitOfWork.DoctorRepo.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            _unitOfWork.DoctorRepo.Delete(doctor);
            _unitOfWork.Commit();
            return NoContent();
        }



        [HttpPut]
        public IActionResult UpdateDoctor(int Id, [FromBody] Doctor doctor)
        {

            var p = _unitOfWork.DoctorRepo.GetById(doctor.DoctorId);
            if (p == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update the properties of p with the values from the product object
            p.FullName = doctor.FullName;
            p.Gender = doctor.Gender;
            p.DateOfBirth = doctor.DateOfBirth;
            p.ContactNumber = doctor.ContactNumber;
            p.Email = doctor.Email;
            p.Address = doctor.Address;

            _unitOfWork.DoctorRepo.Update(p);
            _unitOfWork.Commit();
            return Ok(p);
        }
    }
}
