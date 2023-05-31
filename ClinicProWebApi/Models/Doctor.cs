using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClinicProWebApi.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }


        [Required(ErrorMessage = "Please enter the patient's full name.")]
        [MaxLength(100, ErrorMessage = "The full name must not exceed 100 characters.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Please select the patient's gender.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please enter the patient's date of birth.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter the patient's contact number.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "The contact number must be a 10-digit number.")]
        public string? ContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter the patient's email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter the patient's address.")]
        public string? Address { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }

    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}

