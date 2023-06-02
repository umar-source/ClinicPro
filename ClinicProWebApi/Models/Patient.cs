using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicProWebApi.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The full name must not exceed 100 characters.")]
        public string? FullName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
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

        [Required]
        public string? City { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "The postal code must be a 5-digit number.")]
        public string? PostalCode { get; set; }

        [Display(Name = "Insurance Provider")]
        public string? InsuranceProvider { get; set; }


        // [JsonIgnore] prevents a property from being Serialized & Deserialized
        [JsonIgnore] 
        public virtual Department? Department { get; set; }
        [JsonIgnore]
        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
