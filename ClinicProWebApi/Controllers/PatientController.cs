using ClinicProWebApi.Models;
using ClinicProWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicProWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public IActionResult GetAllPatient()
        {
            try
            {
                var patient = _unitOfWork.PatientRepo.GetAll();
                if (patient == null)
                {
                    return NotFound("Zero Patients");
                }
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
          
        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(int id)
        {
        }

         */

        [HttpPost]
        public IActionResult CreatePatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.PatientRepo.Add(patient);
            _unitOfWork.Commit();
            CreatedAtAction("GetPatient", new { id = patient.PatientId }, patient);
            //allows us to set Location URI of the newly created resource by specifying the name of an action where we can retrieve our resource.
            // actionName - by default it is controller method name but can also be assigned using, routeValues - info necessary to generate a correct URL, value - content to return in a response body


            return Ok(patient);
        }



        [HttpGet("{Id}", Name = "PatientById")]
        public IActionResult GetPatientById(int Id)
        {
            var patient = _unitOfWork.PatientRepo.GetById(Id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }


        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _unitOfWork.PatientRepo.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            _unitOfWork.PatientRepo.Delete(patient);
            _unitOfWork.Commit();
            return NoContent();
        }



        [HttpPut]
        public IActionResult UpdatePatient([FromBody] Patient patient)
        {

            var p = _unitOfWork.PatientRepo.GetById(patient.PatientId);
            if (p == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update the properties of p with the values from the product object
            p.FullName = patient.FullName;
            p.Gender = patient.Gender;
            p.DateOfBirth = patient.DateOfBirth;
            p.ContactNumber = patient.ContactNumber;
            p.Email = patient.Email;
            p.Address = patient.Address;
            p.City = patient.City;
            p.PostalCode = patient.PostalCode;

            _unitOfWork.PatientRepo.Update(p);
            _unitOfWork.Commit();
            return Ok(p);
        }


  
    }
}
