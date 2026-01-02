using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class DisabilityDetail: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public DisabilityType DisabilityType { get; set; } = DisabilityType.None;

        public int? DisabilityPercentage { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
