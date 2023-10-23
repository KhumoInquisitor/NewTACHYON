using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
    public class ProcedureFeedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Have you ever undergone a specialized medical procedure before?")]
        public bool HasUndergoneProcedure { get; set; }

        [Display(Name = "If yes, which procedure was it?")]
        public string ProcedureName { get; set; }

        [Required]
        [Display(Name = "What concerns or fears do you have about the specialized procedure you are considering or are scheduled to undergo?")]
        public string Concerns { get; set; }

        [Required]
        [Display(Name = "How did you decide on the particular procedure or specialist?")]
        public string DecisionReason { get; set; }

        [Display(Name = "After undergoing the procedure, did you experience any unexpected side effects or complications?")]
        public string PostProcedureExperience { get; set; }

        [Required]
        [Display(Name = "How were the side effects or complications managed?")]
        public string ManagementOfSideEffects { get; set; }

        [Required]
        [Range(1, 10)]
        [Display(Name = "On a scale of 1 to 10, how would you rate your overall satisfaction with the procedure and the care you received from the medical staff?")]
        public int OverallSatisfaction { get; set; }
        public double Rating { get; internal set; }

        // Optionally, you can also include other metadata like Timestamp, Patient ID, etc.
    }
}


