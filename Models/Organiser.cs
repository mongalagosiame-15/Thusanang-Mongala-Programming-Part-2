using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    public class Organiser
    {
        [Key]
        public int OrganiserID { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}