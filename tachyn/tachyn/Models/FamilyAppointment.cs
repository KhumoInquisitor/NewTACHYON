using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tachyon.Areas.Identity.Data;

namespace Tachyon.Models
{
    public class FamilyAppointment
    {
        [Key]
        public int AppointmentID { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Time)]
        public DateTime date { get; set; }
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        public virtual TachyonUser MainUser { get; set; }
        [Required]
       
      
        public string? Description { get; set; }
        [Required]
        public string? NurseName { get; set; }
        [Required]
        public DateTime CurrentDate { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }

      

    }
}
