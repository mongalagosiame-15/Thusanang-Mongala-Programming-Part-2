using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public int EventID { get; set; }
        [ForeignKey("EventID")]
        public Event? Event { get; set; }

        [Required, MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(6,2)")]
        public decimal DistanceKM { get; set; }
        public int MaximumParticipants { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
    }
}
