using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayAPI.Models
{
    public class Enrolment
    {
        [Key]
        public int EnrolmentID { get; set; }
        public int ParticipantID { get; set; }
        [ForeignKey("ParticipantID")]
        public Participant? Participant { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

        public DateTime EnrolmentDate { get; set; } = DateTime.UtcNow;
        [Required, MaxLength(20)]
        public string Status { get; set; } = "Active";
        public Result? Result { get; set; }
    }
}