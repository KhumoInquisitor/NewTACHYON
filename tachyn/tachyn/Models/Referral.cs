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
		public int PatientId { get; set; }
		public virtual Patient Patient { get; set; }

		// Specialist details
		[Required]
		[ForeignKey("Specialist")]
		public int SpecialistId { get; set; }
		public string Specialist { get; set; }

		// Referral letter details
		[Required]
		public DateTime Date { get; set; }

		[Required, MaxLength(500)]
		public string Complaint { get; set; }

		[MaxLength(1000)]
		public string MedHistory { get; set; }

		[MaxLength(1000)]
		public string PhyExam { get; set; }

		[MaxLength(1000)]
		public string Notes { get; set; }

		[MaxLength(500)]
		public string BloodTests { get; set; }
	}
}
