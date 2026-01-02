using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class ExtracurricularDetail: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }   // FK → Student.Pid

        public string? Interests { get; set; }  // Comma-separated list: Sports, Music, Coding, Other

        public string? Achievements { get; set; } // Comma-separated: Title | Organization | Year

        [Required]
        public ScholarType ScholarType { get; set; }  // Hosteller / Day Scholar

        public TransportationMethod? TransportMethod { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
