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
	public class Referral
	{
		[Key]
		public int Id { get; set; }
		//patient
		public int patientId { get; set; }
		public string patientName { get; set; }
		public DateTime? dob { get; set; }
		public string patientContact { get; set; }
		//specialist
		public int specialistId { get; set; }
		public string specialistName { get; set; }
		public string specialty { get; set; }
		public string contact { get; set;}
		public string practiseNumber { get; set;}
		//letter
		public DateTime? date { get; set; }
		public string complaint { get; set; }
		public string medHistory { get; set; }
		public string phyExam { get; set; }
		public string notes { get; set; }
		public string bloodTests { get; set; }
	}
}
