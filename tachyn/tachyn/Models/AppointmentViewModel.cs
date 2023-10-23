using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.ComponentModel;
using Tachyon.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
	public class AppointmentViewModel
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string? PatientID { get; set; }
		[ForeignKey("PatientID")]
		public virtual TachyonUser MainUser { get; set; }
		public string Name { get; set; }
		[Required]
		public string Surname { get; set; }
		[Required]
		[Display(Name = "Appointment Date")]
		public DateTime Date { get; set; }
		[Required]
		[Display(Name = "Phone Number")]
		[MaxLength(10)]
		public string PhoneNumber { get; set; }
		[Required]
		[DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid Email address")]
		public string Email { get; set; }
		[Required]
		public string Status { get; set; }
		[Required]
		[MaxLength(13)]
		public string IDNumber { get; set; }
	}
}
