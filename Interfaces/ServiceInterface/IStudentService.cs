using StudentRegistrationForm.DTOs.RequestDTOs;
using StudentRegistrationForm.DTOs.ResponseDTOs;
using StudentRegistrationForm.Models;

namespace StudentRegistrationForm.Interfaces.ServiceInterface
{
    public interface IStudentService
    {
        Task<CompleteResponseDTO> AddStudentAsync(CompleteRequestDTO dto);
        Task<CompleteResponseDTO> GetStudentByIdAsync(int id);
        Task<CompleteResponseDTO> GetStudentByPidAsync(Guid pid);
        Task<List<CompleteResponseDTO>> GetAllStudentsAsync();
        Task DeleteStudentAsync(Guid pid);
        Task<CompleteResponseDTO> UpdateStudentAsync(Guid pid, CompleteRequestDTO dto);
        
        // ✅ NEW: Upload files for existing student
        Task<CompleteResponseDTO> UploadStudentFilesAsync(Guid pid, StudentFileUploadDTO fileDto);
    }
}
