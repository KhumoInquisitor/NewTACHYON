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
        public virtual TachyonUser? User { get; set; }
		[Required]
		[Display(Name = "Patient name:")]
		public string? Name { get; set; }
		[Required]
		[Display(Name = "Patient lastname:")]
		public string? lastName { get; set; }
		[Required]
        [Display(Name = "Choose birth control:")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Nurse name:")]
        public string? NurseName { get; set; }
        [Required]
        [Display(Name = "Current Date:")]
        public DateTime CurrentDate { get; set; }
        [Required]
        [Display(Name = "Appointment Date:")]
        public DateTime AppointmentDate { get; set; }

       
        [Display(Name = " Appointment Status:")]
        public string? status { get; set; }

    }
}
