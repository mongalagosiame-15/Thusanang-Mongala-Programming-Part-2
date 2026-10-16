using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayAPI.Models
{
    public class Result
    {
        [Key]
        public int ResultID { get; set; }
        public int EnrolmentID { get; set; }
        [ForeignKey("EnrolmentID")]
        public Enrolment? Enrolment { get; set; }

        [Required]
        public TimeSpan FinishTime { get; set; }
        public int Position { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
    }
}