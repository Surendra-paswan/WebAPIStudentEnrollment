using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class BankDetail: BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string AccountHolderName { get; set; }

        [Required]
        public BankName BankName { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string Branch { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
