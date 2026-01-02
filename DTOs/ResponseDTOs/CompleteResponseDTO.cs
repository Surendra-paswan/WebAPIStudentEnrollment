using StudentRegistrationForm.EnumValues;

namespace StudentRegistrationForm.DTOs.ResponseDTOs
{
    public class CompleteResponseDTO
    {
        // Student Details - Using Pid instead of Id
        public Guid Pid { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
        public DateTime DateOfBirth { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;

        // Personal Details
        public PersonalDetailsResponseDTO? PersonalDetails { get; set; }

        // Contact Details
        public ContactDetailResponseDTO? ContactDetail { get; set; }

        // Financial Details
        public FinancialDetailResponseDTO? FinancialDetail { get; set; }

        // Bank Details
        public BankDetailResponseDTO? BankDetail { get; set; }

        // Citizenship Details
        public CitizenshipDetailResponseDTO? CitizenshipDetail { get; set; }

        // Academic Enrollment Details
        public AcademicEnrollmentResponseDTO? AcademicEnrollment { get; set; }

        // Declaration
        public DeclarationResponseDTO? Declaration { get; set; }

        // Collections
        public List<AddressResponseDTO>? Addresses { get; set; }
        public List<EmergencyContactResponseDTO>? EmergencyContacts { get; set; }
        public List<DisabilityDetailResponseDTO>? DisabilityDetails { get; set; }
        public List<ParentGuardianResponseDTO>? ParentGuardians { get; set; }
        public List<AcademicHistoryResponseDTO>? AcademicHistories { get; set; }
        public List<ExtracurricularDetailResponseDTO>? ExtracurricularDetails { get; set; }
        public List<StudentDocumentResponseDTO>? Documents { get; set; }

        // Metadata
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    // Response DTO for Personal Details
    public class PersonalDetailsResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public Gender Gender { get; set; }
        public string GenderDisplay => Gender.ToString();
        public Nationality Nationality { get; set; }
        public string NationalityDisplay => Nationality.ToString();
        public BloodGroup? BloodGroup { get; set; }
        public string? BloodGroupDisplay => BloodGroup?.ToString();
        public MaritalStatus? MaritalStatus { get; set; }
        public string? MaritalStatusDisplay => MaritalStatus?.ToString();
        public string? Religion { get; set; }
        public string Ethnicity { get; set; } = string.Empty;
    }

    //Response DTO for Contact Detail
    public class ContactDetailResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public string Email { get; set; } = string.Empty;
        public string? AlternateEmail { get; set; }
        public string PrimaryMobile { get; set; } = string.Empty;
        public string? SecondaryMobile { get; set; }
    }

    // Response DTO for Financial Detail
    public class FinancialDetailResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public FeeCategory FeeCategory { get; set; }
        public string FeeCategoryDisplay => FeeCategory.ToString();
        public ScholarshipType ScholarshipType { get; set; }
        public string ScholarshipTypeDisplay => ScholarshipType.ToString();
        public string? ScholarshipProviderName { get; set; }
        public decimal? ScholarshipAmount { get; set; }
        public bool HasScholarship => ScholarshipAmount > 0;
    }

    // Response DTO for Bank Detail
    public class BankDetailResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public string AccountHolderName { get; set; } = string.Empty;
        public BankName BankName { get; set; }
        public string BankNameDisplay => BankName.ToString();
        public string AccountNumber { get; set; } = string.Empty;
        public string MaskedAccountNumber => AccountNumber.Length > 4 
            ? "****" + AccountNumber.Substring(AccountNumber.Length - 4) 
            : AccountNumber;
        public string Branch { get; set; } = string.Empty;
    }

    // Response DTO for Citizenship Detail
    public class CitizenshipDetailResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public string CitizenshipNumber { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public string IssueDistrict { get; set; } = string.Empty;
    }

    // Response DTO for Academic Enrollment
    public class AcademicEnrollmentResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public Faculty Faculty { get; set; }
        public string FacultyDisplay => Faculty.ToString();
        public AcademicProgram Program { get; set; }
        public string ProgramDisplay => Program.ToString();
        public Level Level { get; set; }
        public string LevelDisplay => Level.ToString();
        public AcademicYear AcademicYear { get; set; }
        public string AcademicYearDisplay => AcademicYear.ToString();
        public Semester Semester { get; set; }
        public string SemesterDisplay => Semester.ToString();
        public Section Section { get; set; }
        public string SectionDisplay => Section.ToString();
        public string RollNumber { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public AcademicStatus AcademicStatus { get; set; }
        public string AcademicStatusDisplay => AcademicStatus.ToString();
    }

    // Response DTO for Declaration
    public class DeclarationResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public bool IsAgreed { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Place { get; set; } = string.Empty;
    }

    // Response DTO for Address
    public class AddressResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public AddressType AddressType { get; set; }
        public string AddressTypeDisplay => AddressType.ToString();
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Municipality { get; set; } = string.Empty;
        public int WardNumber { get; set; }
        public string ToleStreet { get; set; } = string.Empty;
        public string? HouseNumber { get; set; }
        public string FullAddress => $"{ToleStreet}, Ward {WardNumber}, {Municipality}, {District}, {Province}";
    }

    // Response DTO for Emergency Contact
    public class EmergencyContactResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public string ContactName { get; set; } = string.Empty;
        public GardianType Relation { get; set; }
        public string RelationDisplay => Relation.ToString();
        public string ContactNumber { get; set; } = string.Empty;
    }

    // Response DTO for Disability Detail
    public class DisabilityDetailResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public DisabilityType DisabilityType { get; set; }
        public string DisabilityTypeDisplay => DisabilityType.ToString();
        public int? DisabilityPercentage { get; set; }
    }

    // Response DTO for Parent/Guardian
    public class ParentGuardianResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public GardianType ParentType { get; set; }
        public string ParentTypeDisplay => ParentType.ToString();
        public string FullName { get; set; } = string.Empty;
        public string? Occupation { get; set; }
        public string? Designation { get; set; }
        public string? Organization { get; set; }
        public string? WorkDetails => !string.IsNullOrEmpty(Designation) && !string.IsNullOrEmpty(Organization)
            ? $"{Designation} at {Organization}"
            : Organization ?? Occupation;
        public string MobileNumber { get; set; } = string.Empty;
        public string? GardianEmail { get; set; }
        public AnnualIncome? AnnualFamilyIncome { get; set; }
        public string? AnnualFamilyIncomeDisplay => AnnualFamilyIncome?.ToString();
    }

    // Response DTO for Academic History
    public class AcademicHistoryResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public Qualification Qualification { get; set; }
        public string QualificationDisplay => Qualification.ToString();
        public string BoardOrUniversity { get; set; } = string.Empty;
        public string InstitutionName { get; set; } = string.Empty;
        public int PassedYear { get; set; }
        public string DivisionOrGPA { get; set; } = string.Empty;
        public string? MarksheetPath { get; set; }
    }

    // Response DTO for Extracurricular Detail
    public class ExtracurricularDetailResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public string? Interests { get; set; }
        public string? Achievements { get; set; }
        public ScholarType ScholarType { get; set; }
        public string ScholarTypeDisplay => ScholarType.ToString();
        public TransportationMethod? TransportMethod { get; set; }
        public string? TransportMethodDisplay => TransportMethod?.ToString();
    }

    // Response DTO for Student Document
    public class StudentDocumentResponseDTO
    {
        public Guid Pid { get; set; }  // Changed from Id
        public DocumentType DocumentType { get; set; }
        public string DocumentTypeDisplay => DocumentType.ToString();
        public string FilePath { get; set; } = string.Empty;
        public string FileName => Path.GetFileName(FilePath);
        public string FileExtension => Path.GetExtension(FilePath);
    }
}
