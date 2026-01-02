using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class ParentGuardian : BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public GardianType ParentType { get; set; }

        [Required]
        public string FullName { get; set; }
        public string? Occupation { get; set; }
        public string? Designation { get; set; }
        public string? Organization { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        public string? GardianEmail { get; set; }
        public AnnualIncome? AnnualFamilyIncome { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
