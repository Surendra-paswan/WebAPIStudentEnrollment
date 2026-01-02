using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class EmergencyContact: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public GardianType Relation { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
