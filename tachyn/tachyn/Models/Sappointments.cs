using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Tachyon.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;

namespace Tachyon.Models
{
	public class Sappointments
	{
		[Key]
		public int appointmentId { get; set; }
		public DateTime Date { get; set; }
		public int patientID { get; set; }
		public string title { get; set; }
		public string? name { get; set; }
		public string? lastname { get; set; }
		public string phone { get; set; }
	}
}
