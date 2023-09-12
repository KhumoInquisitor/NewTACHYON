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
		public int id { get; set; }
		public int patientID { get; set; }
		public string? name { get; set; }
		public string? lastname { get; set; }
		[DisplayName("Date Of Birth")]
		public string dob { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
		public string phone { get; set; }
		public DateTime Date { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Room { get; set; }
		public string Anesthesia { get; set; }
		public string anesthesiaType { get; set; }
		public string physician { get; set; }
		public string Anesthesiologist { get; set; }
		public string Assistant { get; set; }
		public string InstrumentOperator { get; set; }
		public string description { get; set; }
		public string complications { get; set; }
		public string postProcedure { get; set; }
		public string instructions { get; set; }
		public string disposition { get; set; }
		public string notes { get; set; }
	}
}
