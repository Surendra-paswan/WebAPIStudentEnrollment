using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class CitizenshipDetail: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string CitizenshipNumber { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public string IssueDistrict { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
