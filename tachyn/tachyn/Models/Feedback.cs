using System.ComponentModel.DataAnnotations;

namespace Tachyon.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        [Required]
        public string Message { get; set;}
        [Required]
        //[DataType(dataType: DataType.Date)]
        public DateTime Date { get; set; }
    }
}
