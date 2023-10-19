using Tachyon.Areas.Identity.Data;
using Tachyon.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tachyon.Models
{
    public class Screening
    {
        [Key]
        public int screeningID { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        public virtual TachyonUser? MainUser { get; set; }
       


        //Question
        [Required]
        [DisplayName("1.When was the last time you enganged in sexual intercourse?")]
        public int? intercourse { get; set; }

        [Required]
        [DisplayName("2.When was the last time you had your periods?")]

        public int? period { get; set; }

        [Required]
        [DisplayName("3.Do you have a child?")]

        public int? child { get; set; }

        [Required]
        [DisplayName("4.Have experince any morning sickness?")]

        public int? experience { get; set; }

        [Required]
        [DisplayName("5.do you have allergies?")]
        public int? allergies { get; set; }

        [Required]
        [DisplayName("6.are you taking any medication?")]
        public int? medication { get; set; }

        [Required]
        [DisplayName("7.Have you ever used any contraceptives before?")]
        public int? contraceptives { get; set; }


        [Required]
        [DisplayName("8.Do you use Condom?")]
        public int? condom { get; set; }
        [Required]
        [DisplayName("9.Are they normal,Compared to the past  cycle?")]
        public int? normal { get; set; }
      
       

        public Screening()
        {
            Date = DateTime.Now;

        }
    }
}
