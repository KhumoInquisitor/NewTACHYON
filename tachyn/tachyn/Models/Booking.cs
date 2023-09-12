using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
    public class Booking
    {

        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public DateTime datetimevalue { get; set; }
        [Required]
        public string Department { get; set; }


    }
}
