using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tachyon.Models
{
    public class FamilyFeedBack
    {
        [Key]
        public int FamilyFeedBackID { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? EmailAddress { get; set; }
        [Required]
        public string? Message { get; set;}

    }
}
