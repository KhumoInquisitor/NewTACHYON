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
	public class Patient
	{
		[Key]
		public int patientID { get; set; }
		public string Name { get; set; }
		[DisplayName("Date Of Birth")]
		public string dob { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
		[DisplayName("Phone")]
		public string phone { get; set; }
		public string email { get; set; }
		public string address { get; set; }
	}
}
