using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ClinicProWebApi.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "The full name must not exceed 100 characters.")]
        public string? FullName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please enter the patient's date of birth.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "The contact number must be a 10-digit number.")]
        public string? ContactNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required]
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

