using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class Declaration: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public bool IsAgreed { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        public string Place { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
