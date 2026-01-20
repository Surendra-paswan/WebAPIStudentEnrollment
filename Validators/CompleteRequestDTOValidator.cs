using FluentValidation;
using StudentRegistrationForm.DTOs.RequestDTOs;

namespace StudentRegistrationForm.Validators
{
    public class CompleteRequestDTOValidator : AbstractValidator<CompleteRequestDTO>
    {
        public CompleteRequestDTOValidator()
        {
            //PERSONAL & BIOMETRIC DETAILS 

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .Length(2, 50).WithMessage("First name must be between 2 and 50 characters")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("First name can only contain letters and spaces");

            RuleFor(x => x.MiddleName)
                .MaximumLength(50).WithMessage("Middle name cannot exceed 50 characters")
                .Matches(@"^[a-zA-Z\s]*$").WithMessage("Middle name can only contain letters and spaces")
                .When(x => !string.IsNullOrEmpty(x.MiddleName));

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Last name can only contain letters and spaces");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required")
                .LessThan(DateTime.Today).WithMessage("Date of birth cannot be in the future")
                .Must(BeValidAge).WithMessage("Age must be between 5 and 100 years");

            RuleFor(x => x.PlaceOfBirth)
                .NotEmpty().WithMessage("Place of birth is required")
                .Length(2, 100).WithMessage("Place of birth must be between 2 and 100 characters");

            //RuleFor(x => x.PhotoPath)
            //    .MaximumLength(500).WithMessage("Photo path cannot exceed 500 characters");

            RuleFor(x => x.Nationality)
                .IsInEnum().WithMessage("Invalid nationality");

            RuleFor(x => x.CitizenshipNumber)
                .NotEmpty().WithMessage("Citizenship number is required")
                .Length(5, 50).WithMessage("Citizenship number must be between 5 and 50 characters")
                .Matches(@"^[0-9\-\/]+$").WithMessage("Invalid citizenship number format");

            RuleFor(x => x.IssueDate)
                .NotEmpty().WithMessage("Citizenship issue date is required")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Issue date must be in the past or today");

            RuleFor(x => x.IssueDistrict)
                .NotEmpty().WithMessage("Issue district is required")
                .Length(2, 100).WithMessage("Issue district must be between 2 and 100 characters");

            //CONTACT DETAILS

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters");

            RuleFor(x => x.AlternateEmail)
                .EmailAddress().WithMessage("Invalid alternate email format")
                .MaximumLength(100).WithMessage("Alternate email cannot exceed 100 characters")
                .When(x => !string.IsNullOrEmpty(x.AlternateEmail));

            RuleFor(x => x.PrimaryMobile)
                .NotEmpty().WithMessage("Primary mobile number is required")
                .Matches(@"^(97|98)\d{8}$").WithMessage("Mobile number must start with 97 or 98 and be exactly 10 digits");

            RuleFor(x => x.SecondaryMobile)
                .Matches(@"^(97|98)\d{8}$").WithMessage("Secondary mobile must start with 97 or 98 and be exactly 10 digits")
                .When(x => !string.IsNullOrEmpty(x.SecondaryMobile));

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("Invalid gender");

            RuleFor(x => x.Ethnicity)
                .NotEmpty().WithMessage("Ethnicity is required")
                .Length(2, 50).WithMessage("Ethnicity must be between 2 and 50 characters");

            RuleFor(x => x.Religion)
                .MaximumLength(50).WithMessage("Religion cannot exceed 50 characters")
                .When(x => !string.IsNullOrEmpty(x.Religion));

            //ACADEMIC ENROLLMENT DETAILS

            RuleFor(x => x.Faculty)
                .IsInEnum().WithMessage("Invalid faculty");

            RuleFor(x => x.Program)
                .IsInEnum().WithMessage("Invalid program");

            RuleFor(x => x.Level)
                .IsInEnum().WithMessage("Invalid level");

            RuleFor(x => x.AcademicYear)
                .IsInEnum().WithMessage("Invalid academic year");

            RuleFor(x => x.Semester)
                .IsInEnum().WithMessage("Invalid semester");

            RuleFor(x => x.Section)
                .IsInEnum().WithMessage("Invalid section");

            RuleFor(x => x.RollNumber)
                .NotEmpty().WithMessage("Roll number is required")
                .Length(1, 20).WithMessage("Roll number must be between 1 and 20 characters");

            RuleFor(x => x.RegistrationNumber)
                .NotEmpty().WithMessage("Registration number is required")
                .Length(1, 50).WithMessage("Registration number must be between 1 and 50 characters");

            RuleFor(x => x.EnrollmentDate)
                .NotEmpty().WithMessage("Enrollment date is required");

            RuleFor(x => x.AcademicStatus)
                .IsInEnum().WithMessage("Invalid academic status");

            // FINANCIAL DETAILS

            RuleFor(x => x.FeeCategory)
                .IsInEnum().WithMessage("Invalid fee category");

            RuleFor(x => x.ScholarshipType)
                .IsInEnum().WithMessage("Invalid scholarship type");

            RuleFor(x => x.ScholarshipProviderName)
                .MaximumLength(200).WithMessage("Scholarship provider name cannot exceed 200 characters")
                .When(x => !string.IsNullOrEmpty(x.ScholarshipProviderName));

            RuleFor(x => x.ScholarshipAmount)
                .InclusiveBetween(0, 10000000).WithMessage("Scholarship amount must be between 0 and 10,000,000")
                .When(x => x.ScholarshipAmount.HasValue);

            //BANK DETAILS

            RuleFor(x => x.AccountHolderName)
                .NotEmpty().WithMessage("Account holder name is required")
                .Length(2, 100).WithMessage("Account holder name must be between 2 and 100 characters")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Account holder name can only contain letters and spaces");

            RuleFor(x => x.BankName)
                .IsInEnum().WithMessage("Invalid bank name");

            RuleFor(x => x.AccountNumber)
                .NotEmpty().WithMessage("Account number is required")
                .Length(5, 20).WithMessage("Account number must be between 5 and 20 characters")
                .Matches(@"^[0-9]+$").WithMessage("Account number must contain only digits");

            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("Branch is required")
                .Length(2, 100).WithMessage("Branch must be between 2 and 100 characters");

            //DECLARATION

            RuleFor(x => x.IsAgreed)
                .Equal(true).WithMessage("You must agree to the terms and conditions");

            RuleFor(x => x.ApplicationDate)
                .NotEmpty().WithMessage("Application date is required");

            RuleFor(x => x.Place)
                .NotEmpty().WithMessage("Place is required")
                .Length(2, 100).WithMessage("Place must be between 2 and 100 characters");

            //NESTED COLLECTIONS VALIDATION

            RuleForEach(x => x.Addresses).SetValidator(new AddressDTOValidator());
            RuleForEach(x => x.EmergencyContacts).SetValidator(new EmergencyContactDTOValidator());
            RuleForEach(x => x.DisabilityDetails).SetValidator(new DisabilityDetailDTOValidator());
            RuleForEach(x => x.ParentGuardians).SetValidator(new ParentGuardianDTOValidator());
            RuleForEach(x => x.AcademicHistories).SetValidator(new AcademicHistoryDTOValidator());
            RuleForEach(x => x.ExtracurricularDetails).SetValidator(new ExtracurricularDetailDTOValidator());
            RuleForEach(x => x.Documents).SetValidator(new StudentDocumentDTOValidator());
        }

        // Custom validation method for age
        private bool BeValidAge(DateTime dateOfBirth)
        {
            var age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
            return age >= 5 && age <= 100;
        }
    }

    //ADDRESS VALIDATOR
    public class AddressDTOValidator : AbstractValidator<AddressDTO>
    {
        public AddressDTOValidator()
        {
            RuleFor(x => x.AddressType)
                .IsInEnum().WithMessage("Invalid address type");

            RuleFor(x => x.Province)
                .NotEmpty().WithMessage("Province is required")
                .Length(2, 50).WithMessage("Province must be between 2 and 50 characters");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("District is required")
                .Length(2, 50).WithMessage("District must be between 2 and 50 characters");

            RuleFor(x => x.Municipality)
                .NotEmpty().WithMessage("Municipality is required")
                .Length(2, 100).WithMessage("Municipality must be between 2 and 100 characters");

            RuleFor(x => x.WardNumber)
                .NotEmpty().WithMessage("Ward number is required")
                .InclusiveBetween(1, 50).WithMessage("Ward number must be between 1 and 50");

            RuleFor(x => x.ToleStreet)
                .NotEmpty().WithMessage("Tole/Street is required")
                .Length(2, 100).WithMessage("Tole/Street must be between 2 and 100 characters");

            RuleFor(x => x.HouseNumber)
                .MaximumLength(50).WithMessage("House number cannot exceed 50 characters")
                .When(x => !string.IsNullOrEmpty(x.HouseNumber));
        }
    }

    //EMERGENCY CONTACT VALIDATOR
    public class EmergencyContactDTOValidator : AbstractValidator<EmergencyContactDTO>
    {
        public EmergencyContactDTOValidator()
        {
            RuleFor(x => x.ContactName)
                .NotEmpty().WithMessage("Emergency contact name is required")
                .Length(2, 100).WithMessage("Contact name must be between 2 and 100 characters")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Contact name can only contain letters and spaces");

            RuleFor(x => x.Relation)
                .IsInEnum().WithMessage("Invalid relation type");

            RuleFor(x => x.ContactNumber)
                .NotEmpty().WithMessage("Emergency contact number is required")
                .Matches(@"^(97|98)\d{8}$").WithMessage("Contact number must start with 97 or 98 and be exactly 10 digits");
        }
    }

    //DISABILITY DETAIL VALIDATOR 
    public class DisabilityDetailDTOValidator : AbstractValidator<DisabilityDetailDTO>
    {
        public DisabilityDetailDTOValidator()
        {
            RuleFor(x => x.DisabilityType)
                .IsInEnum().WithMessage("Invalid disability type");

            RuleFor(x => x.DisabilityPercentage)
                .InclusiveBetween(0, 100).WithMessage("Disability percentage must be between 0 and 100")
                .When(x => x.DisabilityPercentage.HasValue);
        }
    }

    //PARENT/GUARDIAN VALIDATOR
    public class ParentGuardianDTOValidator : AbstractValidator<ParentGuardianDTO>
    {
        public ParentGuardianDTOValidator()
        {
            RuleFor(x => x.ParentType)
                .IsInEnum().WithMessage("Invalid parent/guardian type");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required")
                .Length(2, 100).WithMessage("Full name must be between 2 and 100 characters")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Full name can only contain letters and spaces");

            RuleFor(x => x.Occupation)
                .MaximumLength(100).WithMessage("Occupation cannot exceed 100 characters")
                .When(x => !string.IsNullOrEmpty(x.Occupation));

            RuleFor(x => x.Designation)
                .MaximumLength(100).WithMessage("Designation cannot exceed 100 characters")
                .When(x => !string.IsNullOrEmpty(x.Designation));

            RuleFor(x => x.Organization)
                .MaximumLength(200).WithMessage("Organization cannot exceed 200 characters")
                .When(x => !string.IsNullOrEmpty(x.Organization));

            RuleFor(x => x.MobileNumber)
                .NotEmpty().WithMessage("Mobile number is required")
                .Matches(@"^(97|98)\d{8}$").WithMessage("Mobile number must start with 97 or 98 and be exactly 10 digits");

            RuleFor(x => x.GardianEmail)
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters")
                .When(x => !string.IsNullOrEmpty(x.GardianEmail));

            RuleFor(x => x.AnnualFamilyIncome)
                .IsInEnum().WithMessage("Invalid annual income")
                .When(x => x.AnnualFamilyIncome.HasValue);
        }
    }

    //ACADEMIC HISTORY VALIDATOR
    public class AcademicHistoryDTOValidator : AbstractValidator<AcademicHistoryDTO>
    {
        public AcademicHistoryDTOValidator()
        {
            RuleFor(x => x.Qualification)
                .IsInEnum().WithMessage("Invalid qualification");

            RuleFor(x => x.BoardOrUniversity)
                .NotEmpty().WithMessage("Board or University is required")
                .Length(2, 200).WithMessage("Board/University must be between 2 and 200 characters");

            RuleFor(x => x.InstitutionName)
                .NotEmpty().WithMessage("Institution name is required")
                .Length(2, 200).WithMessage("Institution name must be between 2 and 200 characters");

            RuleFor(x => x.PassedYear)
                .NotEmpty().WithMessage("Passed year is required")
                .InclusiveBetween(1950, DateTime.Today.Year).WithMessage($"Passed year must be between 1950 and {DateTime.Today.Year}");

            RuleFor(x => x.DivisionOrGPA)
                .NotEmpty().WithMessage("Division or GPA is required")
                .Length(1, 20).WithMessage("Division/GPA must be between 1 and 20 characters");

            //RuleFor(x => x.MarksheetPath)
            //    .MaximumLength(500).WithMessage("Marksheet path cannot exceed 500 characters")
            //    .When(x => !string.IsNullOrEmpty(x.MarksheetPath));
        }
    }

    //EXTRACURRICULAR DETAIL VALIDATOR 
    public class ExtracurricularDetailDTOValidator : AbstractValidator<ExtracurricularDetailDTO>
    {
        public ExtracurricularDetailDTOValidator()
        {
            RuleFor(x => x.Interests)
                .MaximumLength(500).WithMessage("Interests cannot exceed 500 characters")
                .When(x => !string.IsNullOrEmpty(x.Interests));

            RuleFor(x => x.Achievements)
                .MaximumLength(500).WithMessage("Achievements cannot exceed 500 characters")
                .When(x => !string.IsNullOrEmpty(x.Achievements));

            RuleFor(x => x.ScholarType)
                .IsInEnum().WithMessage("Invalid scholar type (Hosteller or Day Scholar)");

            RuleFor(x => x.TransportMethod)
                .IsInEnum().WithMessage("Invalid transportation method")
                .When(x => x.TransportMethod.HasValue);
        }
    }

    // ===== STUDENT DOCUMENT VALIDATOR =====
    public class StudentDocumentDTOValidator : AbstractValidator<StudentDocumentDTO>
    {
        public StudentDocumentDTOValidator()
        {
            //RuleFor(x => x.DocumentType)
            //    .IsInEnum().WithMessage("Invalid document type");

            //RuleFor(x => x.FilePath)
            //    .NotEmpty().WithMessage("File path is required")
            //    .Length(1, 500).WithMessage("File path must be between 1 and 500 characters");
        }
    }
}