using System.ComponentModel;

using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
    public class Chronic_Report
    {
       public int ID { get; set; }
        [DisplayName("Medication ")]
        public string Name { get; set; }
        public int Dosage { get; set; }
        public DateTime ordered { get; set; }

        internal static object GetAllMedications()
        {
            throw new NotImplementedException();
        }
       
        //public int MedicationCount { get; private set; }

        //// Add medication to the repository
        //public void AddMedication(Chronic_Report medication)
        //{
        //    // Add the medication to your data source
        //    medications.Add(medication);

        //    // Increment the count
        //    MedicationCount++;
        //}
    }
}
