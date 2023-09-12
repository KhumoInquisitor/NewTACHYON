using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
	public class FillingPrescription
	{
		public int ID { get; set; }
		[Required]
		public DateTime Date { get; set; }
		[Required]
		[DisplayName("First Name ")]
		public string PatientName { get; set; }
		[Required]
		[DisplayName("Date Of Birth")]
		public DateTime DateOfBirth { get; set; }
		[Required]
		public string Allergies { get; set; }
		[Required]
		public string Weight { get; set; }
		[Required]
		[DisplayName("Medication")]
		public string DrugsName { get; set; }
		[Required]
		[DisplayName("Unit(Syrup/Syrup)")]
		public int Unit { get; set; }
		[Required]
		[DisplayName("Dosage(Per Day)")]
		public int Dosage { get; set; }
		[Required]
		[DisplayName("Diet")]
		public string DietToFollow { get; set; }

	}
}
