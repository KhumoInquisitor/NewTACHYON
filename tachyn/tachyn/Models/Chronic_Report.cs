using System.ComponentModel;

using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
    public class Chronic_Report
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        [Required]
        [DisplayName("Date Of Birth")]
        public DateTime DateOFBirth { get; set; }
        [Required]
        public string? Race { get; set; }
        [Required]
        [DisplayName(" Medication Name")]
        public string NameOfMedication { get; set; }
        [Required]
        [DisplayName("Order Date")]
        public DateTime OrderedDate { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? province { get; set; }
        [Required]
        public int? zip { get; set; }

    }
}
