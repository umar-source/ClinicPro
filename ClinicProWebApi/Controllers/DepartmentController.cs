using ClinicProWebApi.Models;
using ClinicProWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicProWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            var department = _unitOfWork.DepartmentRepo.GetAll();
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        /*
          
        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(int id)
        {
        }

         */

        [HttpPost]
        public IActionResult CreateDepartment([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.DepartmentRepo.Add(department);
            _unitOfWork.Commit();
            CreatedAtAction("GetDepartment", new { id = department.DepartmentId }, department);

            return Ok(department);
        }



        [HttpGet("{Id}", Name = "DepartmentById")]
        public IActionResult DepartmentById(int Id)
        {
            var doctor = _unitOfWork.DepartmentRepo.GetById(Id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }


        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepo.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            _unitOfWork.DepartmentRepo.Delete(department);
            _unitOfWork.Commit();
            return NoContent();
        }



        [HttpPut("{Id}")]
        public IActionResult UpdateDepartment(int Id, [FromBody] Department department)
        {

            var d = _unitOfWork.DepartmentRepo.GetById(Id);

            if (d == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update the properties of p with the values from the product object
            d.DepartmentName = department.DepartmentName;
            d.Description = department.Description;
            d.HeadOfDepartment = department.HeadOfDepartment;
            d.PhoneNumber = department.PhoneNumber;
            d.Email = department.Email;

            _unitOfWork.DepartmentRepo.Update(d);
            _unitOfWork.Commit();
            return Ok(d);
        }
    }
}
