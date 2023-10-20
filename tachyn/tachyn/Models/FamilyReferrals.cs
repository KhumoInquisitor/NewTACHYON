using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tachyon.Areas.Identity.Data;

namespace Tachyon.Models
{
    public class FamilyReferrals
    {
        [Key]
        public int FamilyPrescriptionID { get; set; }
        [Required]
        [DisplayName("Patient Name")]
        public string? ID { get; set; }
        [ForeignKey("ManageFileID")]
        public virtual TachyonUser? TachyonUser { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? NurseName { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public string? ReferralName { get; set; }
       
    }
}
