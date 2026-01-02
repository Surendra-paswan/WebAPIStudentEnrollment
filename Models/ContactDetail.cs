using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class ContactDetail: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [EmailAddress]
        public string? AlternateEmail { get; set; }

        [Required]
        public string PrimaryMobile { get; set; }

        public string? SecondaryMobile { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
