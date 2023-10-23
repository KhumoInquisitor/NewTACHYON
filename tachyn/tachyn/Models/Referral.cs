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
using Humanizer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Tachyon.Models
{
	public class Referral
	{
		[Key]
		public int Id { get; set; }

		// Patient details
		[Required]
		[ForeignKey("Patient")]
		public int patientId { get; set; }

		// Specialist details
		[Required]
		[ForeignKey("Specialist")]
		public int specialistId { get; set; }
		public string specialist { get; set; }

		// Referral letter details
		[Required]
		public DateTime date { get; set; }

		[Required]
		public string complaint { get; set; }

		
		public string medHistory { get; set; }

		
		public string phyExam { get; set; }

		
		public string notes { get; set; }

		
		public string bloodTests { get; set; }
	}
}
