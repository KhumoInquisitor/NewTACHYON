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
	public class LabTest
	{
		public int id { get; set; }
		public int patientID { get; set; }
		public string? name { get; set; }
		public string? lastname { get; set; }
		[DisplayName("Date Of Birth")]
		public string dob { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
		public DateTime Date { get; set; }
		public string physician { get; set; }
		public string testName { get; set; }
		public string results { get; set; }
		public string interpretation { get; set; }
		public string recommendations { get; set; }
	}
}
