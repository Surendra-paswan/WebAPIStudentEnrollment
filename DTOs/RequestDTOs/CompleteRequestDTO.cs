using StudentRegistrationForm.EnumValues;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace StudentRegistrationForm.DTOs.RequestDTOs
{
    public class CompleteRequestDTO
    {
        // Student Details
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;


        // Personal Details
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; } = EnumValues.Nationality.Nepal;
        public BloodGroup? BloodGroup { get; set; } = EnumValues.BloodGroup.O_Positive;
        public MaritalStatus? MaritalStatus { get; set; } = EnumValues.MaritalStatus.Single;
        public string? Religion { get; set; } = string.Empty;
        public string Ethnicity { get; set; } = string.Empty;

        // Contact Details
        public string Email { get; set; } = string.Empty;
        public string? AlternateEmail { get; set; } = string.Empty;
        public string PrimaryMobile { get; set; } = string.Empty;
        public string? SecondaryMobile { get; set; } = string.Empty;

        // Financial details
        public FeeCategory FeeCategory { get; set; } = 0;
        public ScholarshipType ScholarshipType { get; set; } = 0;
        public string? ScholarshipProviderName { get; set; } = string.Empty;
        public decimal? ScholarshipAmount { get; set; } = 0;

        // Bank Details
        public string AccountHolderName { get; set; } = string.Empty;
        public BankName BankName { get; set; } = 0;
        public string AccountNumber { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;

        // Citizenship Details
        public string CitizenshipNumber { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; } = DateTime.MinValue;
        public string IssueDistrict { get; set; } = string.Empty;

        // Academic Enrollment Details
        public Faculty Faculty { get; set; } = 0;
        public AcademicProgram Program { get; set; } = 0;
        public Level Level { get; set; } = 0;
        public AcademicYear AcademicYear { get; set; } = 0;
        public Semester Semester { get; set; } = 0;
        public Section Section { get; set; } = 0;
        public string RollNumber { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; } = DateTime.MinValue;
        public AcademicStatus AcademicStatus { get; set; } = 0;

        // Declaration
        public bool IsAgreed { get; set; } = false;
        public DateTime ApplicationDate { get; set; } = DateTime.MinValue;
        public string Place { get; set; } = string.Empty;

        // CHANGED TO LISTS - Multiple entries support
        public List<AddressDTO>? Addresses { get; set; } = new List<AddressDTO>();
        public List<EmergencyContactDTO>? EmergencyContacts { get; set; } = new List<EmergencyContactDTO>();
        public List<DisabilityDetailDTO>? DisabilityDetails { get; set; } = new List<DisabilityDetailDTO>();
        public List<ParentGuardianDTO>? ParentGuardians { get; set; } = new List<ParentGuardianDTO>();
        public List<AcademicHistoryDTO>? AcademicHistories { get; set; } = new List<AcademicHistoryDTO>();
        public List<ExtracurricularDetailDTO>? ExtracurricularDetails { get; set; } = new List<ExtracurricularDetailDTO>();
        public List<StudentDocumentDTO>? Documents { get; set; } = new List<StudentDocumentDTO>();
    }

    // DTO for Address
    public class AddressDTO
    {
        [Required]
        public AddressType AddressType { get; set; }

        [Required]
        public string Province { get; set; } = string.Empty;

        [Required]
        public string District { get; set; } = string.Empty;

        [Required]
        public string Municipality { get; set; } = string.Empty;

        [Required]
        public int WardNumber { get; set; }

        [Required]
        public string ToleStreet { get; set; } = string.Empty;

        public string? HouseNumber { get; set; } = string.Empty;
    }

    // DTO for Emergency Contact
    public class EmergencyContactDTO
    {
        [Required]
        public string ContactName { get; set; } = string.Empty;

        [Required]
        public GardianType Relation { get; set; }

        [Required]
        public string ContactNumber { get; set; } = string.Empty;
    }

    // DTO for Disability Detail
    public class DisabilityDetailDTO
    {
        [Required]
        public DisabilityType DisabilityType { get; set; }

        public int? DisabilityPercentage { get; set; }
    }

    // DTO for Parent/Guardian
    public class ParentGuardianDTO
    {
        [Required]
        public GardianType ParentType { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        public string? Occupation { get; set; } = string.Empty;
        public string? Designation { get; set; } = string.Empty;
        public string? Organization { get; set; } = string.Empty;

        [Required]
        public string MobileNumber { get; set; } = string.Empty;

        public string? GardianEmail { get; set; } = string.Empty;
        public AnnualIncome? AnnualFamilyIncome { get; set; }
    }

    //DTO for Academic History
    public class AcademicHistoryDTO
    {
        [Required]
        public Qualification Qualification { get; set; }

        [Required]
        public string BoardOrUniversity { get; set; } = string.Empty;

        [Required]
        public string InstitutionName { get; set; } = string.Empty;

        [Required]
        public int PassedYear { get; set; }

        [Required]
        public string DivisionOrGPA { get; set; } = string.Empty;

        public string? MarksheetPath { get; set; } = string.Empty;
    }

    // DTO for Extracurricular Detail
    public class ExtracurricularDetailDTO
    {
        public string? Interests { get; set; } = string.Empty;
        public string? Achievements { get; set; } = string.Empty;

        [Required]
        public ScholarType ScholarType { get; set; }

        public TransportationMethod? TransportMethod { get; set; }
    }

    // DTO for Student Document
    public class StudentDocumentDTO
    {
        [Required]
        public DocumentType DocumentType { get; set; }

        [Required]
        public string FilePath { get; set; } = string.Empty;
    }
}
