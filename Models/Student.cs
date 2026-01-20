using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationForm.Models
{
    public class Student: BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } 
        [Required]  
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PlaceOfBirth { get; set; }
        [Required]
        public string PhotoPath { get; set; }


        // navigation properties
        // One-to-One Navigation Properties
        public virtual PersonalDetails? PersonalDetails { get; set; }
        public virtual ContactDetail? ContactDetail { get; set; }
        public virtual FinancialDetail? FinancialDetail { get; set; }
        public virtual BankDetail? BankDetail { get; set; }
        public virtual CitizenshipDetail? CitizenshipDetail { get; set; }
        public virtual AcademicEnrollment? AcademicEnrollment { get; set; }
        public virtual Declaration? Declaration { get; set; }

        // One-to-Many Navigation Properties
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();
        public virtual ICollection<DisabilityDetail> DisabilityDetails { get; set; } = new List<DisabilityDetail>();
        public virtual ICollection<ParentGuardian> ParentGuardians { get; set; } = new List<ParentGuardian>();
        public virtual ICollection<AcademicHistory> AcademicHistories { get; set; } = new List<AcademicHistory>();
        public virtual ICollection<ExtracurricularDetail> ExtracurricularDetails { get; set; } = new List<ExtracurricularDetail>();
        public virtual ICollection<StudentDocument> Documents { get; set; } = new List<StudentDocument>();
    }

}
