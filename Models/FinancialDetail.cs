using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class FinancialDetail: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public FeeCategory FeeCategory { get; set; }

        public ScholarshipType ScholarshipType { get; set; }
        public string? ScholarshipProviderName { get; set; }
        public decimal? ScholarshipAmount { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
