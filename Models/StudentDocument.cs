using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class StudentDocument: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public DocumentType DocumentType { get; set; }

        [Required]
        public string FilePath { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
