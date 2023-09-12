using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
    public class Collection
    {
        public int ID { get; set; }
        
        [Required]
        public int OrderNo { get; set; }
        [Required]
        public DateTime  DateOfBirth { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [Required]
        [DisplayName("Medication Name")]
        public string MedicationName { get; set;}
        [Required]
        public string Collected { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
