using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tachyon.Models
{
    public class TrackMenstruation
    {
        [Key]
        public int TrackID { get; set; }
        [Required]
        public DateTime CurrentDate { get; set; }
        [Required]

        public DateTime LastPeriodDate { get; set; }

        public int difference { get; set; }
    }
}
