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
	public class Procedure
	{
		[Key]
		public int Id { get; set; }
		//patient
		public string patientId { get; set; }
		public string patientName { get; set; }
		public DateTime? dob { get; set; }
		//personnel
		public string specialistName { get; set; }
		public int specialistId { get; set;}
		public string anesthesiaProvider { get; set; }
		public string anesthesiaType { get; set; }
		//info
		public DateTime? date { get; set; }
		public int procedureId { get; set; }
		public string procedureName { get; set; }
		public string procedureDescription { get; set; }
		public string complications { get; set;}
		public string instructions { get;set; }
		public string notes { get; set; }
		//vital signs
		public string bodyTemp { get; set; }
		public string pulseRate { get; set; }
		public string respRate { get; set; }
		public string bloodPressure { get; set; }
	}
}
