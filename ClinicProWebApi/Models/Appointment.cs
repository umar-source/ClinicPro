using System.ComponentModel.DataAnnotations;

namespace ClinicProWebApi.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Display(Name = "Patient Name")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string? PatientName { get; set; }

        [Display(Name = "Appointment Date")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        [Display(Name = "Doctor")]
        [Required(ErrorMessage = "The {0} field is required.")]
        public int DoctorId { get; set; }

        [Display(Name = "Appointment Type")]
        [Required(ErrorMessage = "The {0} field is required.")]
        public AppointmentType AppointmentType { get; set; }

        [Display(Name = "Reason")]
        [StringLength(500, ErrorMessage = "The {0} field cannot exceed {1} characters.")]
        public string? Reason { get; set; }

        public virtual Patient? Patient { get; set; }


        public virtual Doctor? Doctor { get; set; }
    }
    public enum AppointmentType
    {
        [Display(Name = "General Check-up")]
        GeneralCheckup,

        [Display(Name = "Specialist Consultation")]
        SpecialistConsultation,

        [Display(Name = "Diagnostic Test")]
        DiagnosticTest,

        // Add more appointment types as needed
    }
}
