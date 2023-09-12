using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tachyon.Areas.Identity.Data;
namespace Tachyon.Models
{
	public class FamilyScrenning
	{
		[Key]
		public int screnningID { get; set; }
		[Required]
		[DisplayName(" did you have period this month?")]
		public string? Period { get; set; }
        [Required]
        [DisplayName(" did you have Child?")]
        public string? Child { get; set; }
        [Required]
        [DisplayName(" did you have sexual intercourse in the past 2 weeks?")]
        public string? intercourse { get; set; }

    }
}
