using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationForm.Models
{
    public class Address : BaseEntity
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public AddressType AddressType { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string Municipality { get; set; }

        [Required]
        public int WardNumber { get; set; }

        [Required]
        public string ToleStreet { get; set; }

        public string? HouseNumber { get; set; }

        // Navigation property
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;
    }
}
