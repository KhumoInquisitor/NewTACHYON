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
	public class PatientProgress
	{
		public int id { get; set; }
		public int patientID { get; set; }
		public string? name { get; set; }
		public string? lastname { get; set; }
		public int age { get; set; }
		public string room { get; set; }
		public int Day { get; set; }
		public string Breakfast { get; set; }
		public string Lunch { get; set; }
		public string Dinner { get; set; }
		public string Snacks { get; set; }
		public string Color { get; set; }
		public string Consistency { get; set; }
		public string Amount { get; set; }
		public int Weight { get; set; }
		public int Saturation { get; set; }
		public int FluidBalance { get; set; }
		public int Intake { get; set; }
		public int Output { get; set; }
		public int Temperature { get; set; }
		public int BloodPressure { get; set; }
		public int HeartRate { get; set; }
		public string Transfusion { get; set; }
		public int AntibioticTreatment { get; set; }
	}
}
