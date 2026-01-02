using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class AcademicHistory: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }   

        [Required]
        public Qualification Qualification { get; set; } 

        [Required]
        public string BoardOrUniversity { get; set; }

        [Required]
        public string InstitutionName { get; set; }

        [Required]
        public int PassedYear { get; set; }

        [Required]
        public string DivisionOrGPA { get; set; }

        public string? MarksheetPath { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
