using Microsoft.AspNetCore.Http;

namespace StudentRegistrationForm.DTOs.RequestDTOs
{
    public class StudentFileUploadDTO
    {
        //Student Photo
        public IFormFile? PhotoFile { get; set; }

        // Document Files
        public IFormFile? SignatureFile { get; set; }
        public IFormFile? CitizenshipFile { get; set; }
        public IFormFile? CharacterCertificateFile { get; set; }

        // Marksheet Files (one per academic history)
        // Client should send as MarksheetFiles[0], MarksheetFiles[1], etc.
        public List<IFormFile>? MarksheetFiles { get; set; }
    }
}
