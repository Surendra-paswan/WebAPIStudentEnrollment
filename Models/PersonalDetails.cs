using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class PersonalDetails: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Nationality Nationality { get; set; }

        public BloodGroup? BloodGroup { get; set; }

        public MaritalStatus? MaritalStatus { get; set; }

        public string? Religion { get; set; }

        [Required]
        public string? Ethnicity { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
