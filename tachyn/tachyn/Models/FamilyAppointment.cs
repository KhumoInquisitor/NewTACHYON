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
       
      
        public string? Description { get; set; }
        [Required]
        public string? NurseName { get; set; }
        [Required]
        public DateTime CurrentDate { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }

      

    }
}
