using Microsoft.AspNetCore.Mvc;
using StudentRegistrationForm.DTOs.RequestDTOs;
using StudentRegistrationForm.Interfaces.ServiceInterface;

namespace StudentRegistrationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterStudent([FromBody] CompleteRequestDTO studentDto)
        {
            // FluentValidation runs automatically before this!
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "Validation failed. Please check the errors.",
                    Success = false,
                    Errors = ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                        )
                });
            }

            try
            {
                var response = await _studentService.AddStudentAsync(studentDto);
                return Ok(new
                {
                    Message = "Student registered successfully.",
                    Success = true,
                    Data = response
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error: {ex.Message}", Success = false });
            }
        }

        [HttpPost("{pid:guid}/upload-files")]
        public async Task<IActionResult> UploadStudentFiles(Guid pid, [FromForm] StudentFileUploadDTO fileDto)
        {
            // FluentValidation runs automatically!
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "File validation failed. Please check file requirements.",
                    Success = false,
                    Errors = ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                        )
                });
            }

            try
            {
                var response = await _studentService.UploadStudentFilesAsync(pid, fileDto);
                return Ok(new
                {
                    Message = "Files uploaded successfully.",
                    Success = true,
                    Data = response
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message, Success = false });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error: {ex.Message}", Success = false });
            }
        }

        [HttpPut("{pid:guid}/update-files")]
        public async Task<IActionResult> UpdateStudentFiles(Guid pid, [FromForm] StudentFileUploadDTO fileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "File validation failed. Please check file requirements.",
                    Success = false,
                    Errors = ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                        )
                });
            }

            try
            {
                var response = await _studentService.UploadStudentFilesAsync(pid, fileDto);
                return Ok(new
                {
                    Message = "Files updated successfully.",
                    Success = true,
                    Data = response
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message, Success = false });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error: {ex.Message}", Success = false });
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                return Ok(new
                {
                    Message = "Students retrieved successfully.",
                    Success = true,
                    Count = students.Count,
                    Data = students
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error: {ex.Message}", Success = false });
            }
        }

        [HttpGet("{pid:guid}")]
        public async Task<IActionResult> GetStudentByPid(Guid pid)
        {
            try
            {
                var student = await _studentService.GetStudentByPidAsync(pid);
                return Ok(new
                {
                    Message = "Student retrieved successfully.",
                    Success = true,
                    Data = student
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message, Success = false });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error: {ex.Message}", Success = false });
            }
        }

        [HttpPut("{pid:guid}")]
        public async Task<IActionResult> UpdateStudent(Guid pid, [FromBody] CompleteRequestDTO studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "Validation failed. Please check the errors.",
                    Success = false,
                    Errors = ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                        )
                });
            }

            try
            {
                var response = await _studentService.UpdateStudentAsync(pid, studentDto);
                return Ok(new
                {
                    Message = "Student updated successfully.",
                    Success = true,
                    Data = response
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message, Success = false });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error: {ex.Message}", Success = false });
            }
        }

        [HttpDelete("{pid:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid pid)
        {
            try
            {
                await _studentService.DeleteStudentAsync(pid);
                return Ok(new
                {
                    Message = "Student deleted successfully.",
                    Success = true
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message, Success = false });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error: {ex.Message}", Success = false });
            }
        }
    }
}