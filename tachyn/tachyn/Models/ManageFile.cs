
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tachyon.Models
{
    public class ManageFile
    {
        [Key]
        public int ManageFileID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set;}
        public string? Gender { get; set;}
        [Required]
        [DisplayName("Date Of Birth")]
        public DateTime  DateOFBirth { get; set; }
        [Required]
        public string? Race { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? address { get; set; }
        [Required]
        public string? address2 { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? province { get; set; }
        [Required]
        public int? zip { get; set; }
    }
}
