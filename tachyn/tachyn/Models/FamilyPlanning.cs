using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Tachyon.Models
{
    public class FamilyPlanning
    {
        [Key]
        public int FileID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        [RegularExpression("[1-9][0-9]*",ErrorMessage ="Please enter only numbers")]
        public int Age { get; set; }
        [Required]
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }
    }
  
}
