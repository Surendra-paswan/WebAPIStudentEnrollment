using Microsoft.AspNetCore.Http;

namespace StudentRegistrationForm.Interfaces.ServiceInterface
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string folder);
        Task DeleteFileAsync(string filePath);
        bool FileExists(string filePath);
    }
}
