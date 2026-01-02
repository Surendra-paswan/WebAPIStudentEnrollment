using Microsoft.AspNetCore.Http;
using StudentRegistrationForm.Interfaces.ServiceInterface;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StudentRegistrationForm.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _uploadBasePath;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
            _uploadBasePath = Path.Combine(_environment.ContentRootPath, "Uploads");

            // Ensure Uploads directory exists
            if (!Directory.Exists(_uploadBasePath))
            {
                Directory.CreateDirectory(_uploadBasePath);
            }
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty or null");

            // Create folder path
            var folderPath = Path.Combine(_uploadBasePath, folder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            //Generate unique filename
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(folderPath, fileName);

            //Save file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //Return relative path (for database storage)
            return Path.Combine(folder, fileName).Replace("\\", "/");
        }

        public async Task DeleteFileAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;

            var fullPath = Path.Combine(_uploadBasePath, filePath);
            if (File.Exists(fullPath))
            {
                await Task.Run(() => File.Delete(fullPath));
            }
        }

        public bool FileExists(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            var fullPath = Path.Combine(_uploadBasePath, filePath);
            return File.Exists(fullPath);
        }
    }
}
