using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tachyon.Areas.Identity.Data;

namespace Tachyon.Models
{
    public class Alerts
    {
        [Key]
        public int AlertId { get; set; }
        public string? Message { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public string? Status { get; set; }
        public string? Purpose { get; set; }
        public string? IntendedUser { get; set; }
        [ForeignKey("IntendedUser")]
        public virtual TachyonUser CurrentUser { get; set; }


        public Alerts()
        {
            Status = "New";
            date = DateTime.Now;
            Time = DateTime.Now;
            IntendedUser = "All";
            Purpose = "All";

        }
    }
}
