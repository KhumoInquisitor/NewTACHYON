using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Display(Name="Appointment Date")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name= "Phone Number")]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid Email address")]
        public string Email { get; set; }
        [Required]
        public string Status { get; set;}
        [Required]
        [MaxLength(13)]
        public string IDNumber { get; set;}
    }
}
