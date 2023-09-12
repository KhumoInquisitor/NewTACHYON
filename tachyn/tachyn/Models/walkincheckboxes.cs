using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
    public class walkincheckboxes
    {


        public bool breath { get; set; }
        [Required]
        public bool smell { get; set; }
        [Required]
        public bool cough { get; set; }
        [Required]
        public bool head { get; set; }
        [Required]
        public bool covid { get; set; }
        [Required]

        public string? message { get; set; }

    }
}
