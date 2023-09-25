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
		[Display(Name = "Date")]
		[DataType(DataType.Time)]
		public DateTime date { get; set; }
		public string? PatientID { get; set; }
		[ForeignKey("PatientID")]
		public virtual TachyonUser? mainUser { get; set; }
        [Required]
        public string? status { get; set; }

        [Required]
        [Display(Name ="Do you drnk alcohol?")]
        public string? Drink { get; set; }
		[Required]
		[DisplayName(" did you have period this month?")]
		public string? Period { get; set; }
        [Required]
        [DisplayName(" are you sexual active?")]
        public string? active { get; set; }
        [Required]
        [DisplayName(" do you have Child?")]
        public string? Child { get; set; }
        [Required]
        [DisplayName(" did you have sexual intercourse in the past 2 weeks?")]
        public string? intercourse { get; set; }
        [Required]
        [DisplayName(" do you have any allergies?")]
        public string? allergies { get; set; }
        [Required]
        [DisplayName("are you taking any medication?")]
        public string? medication { get; set; }
        [Required]
        [DisplayName(" Have you ever used any contraceptive before?")]
        public string? contraceptive { get; set; }
    }
}
