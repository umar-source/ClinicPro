using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ClinicProWebApi.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string? DepartmentName { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "The {0} field cannot exceed {1} characters.")]
        public string? Description { get; set; }

        [Display(Name = "Head of Department")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string? HeadOfDepartment { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress(ErrorMessage = "The {0} field is not a valid email address.")]
        public string? Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Patient>? Patients { get; set; }
    }
}
