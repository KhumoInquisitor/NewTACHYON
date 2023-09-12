using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
	public class MedicationRecords
	{
		public int ID { get; set; }
		[Required]
		[DisplayName("Expiry Date")]
		public DateTime ExpiryDate { get; set; }
		[Required]
		[DisplayName(" Medication Name")]
		public string NameOfMedication { get; set; }
		[Required]
		[DisplayName("Order Date")]
		public DateTime OrderedDate { get; set; }
		public string Purpose { get; set; }
		public string Description { get; set; }
		


	}
}
