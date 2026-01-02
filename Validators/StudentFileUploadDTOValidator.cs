using FluentValidation;
using StudentRegistrationForm.DTOs.RequestDTOs;
using System.IO;
using System.Linq;

namespace StudentRegistrationForm.Validators
{
    public class StudentFileUploadDTOValidator : AbstractValidator<StudentFileUploadDTO>
    {
        private readonly string[] _imageExtensions = { ".jpg", ".jpeg", ".png" };
        private readonly string[] _documentExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
        private const int OneMB = 1 * 1024 * 1024;
        private const int TwoMB = 2 * 1024 * 1024;
        private const int FiveMB = 5 * 1024 * 1024;

        public StudentFileUploadDTOValidator()
        {
            // Photo Upload (Passport Size, JPG/PNG, Max 1MB)
            RuleFor(x => x.PhotoFile)
                .Must(file => file == null || _imageExtensions.Contains(Path.GetExtension(file.FileName).ToLowerInvariant()))
                .WithMessage("Photo must be in JPG or PNG format")
                .Must(file => file == null || file.Length <= OneMB)
                .WithMessage("Photo file size cannot exceed 1 MB")
                .When(x => x.PhotoFile != null);

            // Signature Upload (JPG/PNG, Max 1MB)
            RuleFor(x => x.SignatureFile)
                .Must(file => file == null || _imageExtensions.Contains(Path.GetExtension(file.FileName).ToLowerInvariant()))
                .WithMessage("Signature must be in JPG or PNG format")
                .Must(file => file == null || file.Length <= OneMB)
                .WithMessage("Signature file size cannot exceed 1 MB")
                .When(x => x.SignatureFile != null);

            // Citizenship Copy Upload (PDF/JPG, Max 5MB)
            RuleFor(x => x.CitizenshipFile)
                .Must(file => file == null || _documentExtensions.Contains(Path.GetExtension(file.FileName).ToLowerInvariant()))
                .WithMessage("Citizenship document must be in JPG, PNG or PDF format")
                .Must(file => file == null || file.Length <= FiveMB)
                .WithMessage("Citizenship file size cannot exceed 5 MB")
                .When(x => x.CitizenshipFile != null);

            // Character Certificate Upload (PDF, Max 2MB)
            RuleFor(x => x.CharacterCertificateFile)
                .Must(file => file == null || _documentExtensions.Contains(Path.GetExtension(file.FileName).ToLowerInvariant()))
                .WithMessage("Character certificate must be in JPG, PNG or PDF format")
                .Must(file => file == null || file.Length <= TwoMB)
                .WithMessage("Character certificate file size cannot exceed 2 MB")
                .When(x => x.CharacterCertificateFile != null);

            // Marksheet Files (Multiple, PDF/JPG, Max 2MB each)
            RuleForEach(x => x.MarksheetFiles)
                .Must(file => file == null || _documentExtensions.Contains(Path.GetExtension(file.FileName).ToLowerInvariant()))
                .WithMessage("Marksheet must be in JPG, PNG or PDF format")
                .Must(file => file == null || file.Length <= TwoMB)
                .WithMessage("Marksheet file size cannot exceed 2 MB")
                .When(x => x.MarksheetFiles != null && x.MarksheetFiles.Any());
        }
    }
}