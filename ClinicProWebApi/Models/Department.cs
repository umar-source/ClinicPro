using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClinicProWebApi.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string? DepartmentName { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "The {0} field cannot exceed {1} characters.")]
        public string? Description { get; set; }

        [Display(Name = "Head of Department")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string? HeadOfDepartment { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [EmailAddress(ErrorMessage = "The {0} field is not a valid email address.")]
        public string? Email { get; set; }


        public virtual ICollection<Patient>? Patients { get; set; }
    }
}
