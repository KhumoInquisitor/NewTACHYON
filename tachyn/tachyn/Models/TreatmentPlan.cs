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
	public class TreatmentPlan
	{
		[Key]
		public int id { get; set; }
		public int patientID { get; set; }
		public string? name { get; set; }
		public string? lastname { get; set; }
		public string dob { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
		public string procedureName { get; set; }
		public string patientInfo { get; set; }
		public string procedure { get; set; }
		public string postProcedure { get; set; }
		public string recovery { get; set; }
		public string complicationManagement { get; set; }
		public string followup { get; set; }
		
	}
}
