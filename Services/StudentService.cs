using StudentRegistrationForm.DTOs.RequestDTOs;
using StudentRegistrationForm.DTOs.ResponseDTOs;
using StudentRegistrationForm.Interfaces;
using StudentRegistrationForm.Interfaces.ServiceInterface;
using StudentRegistrationForm.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using StudentRegistrationForm.EnumValues;

namespace StudentRegistrationForm.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<CompleteResponseDTO> AddStudentAsync(CompleteRequestDTO dto)
        {
            // ✅ PhotoPath from JSON is already set in dto.PhotoPath
            // No file upload logic here - keep it simple and pure JSON
            
            var student = _mapper.Map<Student>(dto);

            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveChangesAsync();

            return await GetStudentByIdAsync(student.Id);
        }

        public async Task<CompleteResponseDTO> GetStudentByIdAsync(int id)
        {
            var student = await _unitOfWork.Students.GetQueryable()
                .Include(s => s.PersonalDetails)
                .Include(s => s.ContactDetail)
                .Include(s => s.FinancialDetail)
                .Include(s => s.BankDetail)
                .Include(s => s.CitizenshipDetail)
                .Include(s => s.AcademicEnrollment)
                .Include(s => s.Declaration)
                .Include(s => s.Addresses)
                .Include(s => s.EmergencyContacts)
                .Include(s => s.DisabilityDetails)
                .Include(s => s.ParentGuardians)
                .Include(s => s.AcademicHistories)
                .Include(s => s.ExtracurricularDetails)
                .Include(s => s.Documents)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                throw new KeyNotFoundException($"Student not found");

            return _mapper.Map<CompleteResponseDTO>(student);
        }

        public async Task<CompleteResponseDTO> GetStudentByPidAsync(Guid pid)
        {
            var student = await _unitOfWork.Students.GetQueryable()
                .Include(s => s.PersonalDetails)
                .Include(s => s.ContactDetail)
                .Include(s => s.FinancialDetail)
                .Include(s => s.BankDetail)
                .Include(s => s.CitizenshipDetail)
                .Include(s => s.AcademicEnrollment)
                .Include(s => s.Declaration)
                .Include(s => s.Addresses)
                .Include(s => s.EmergencyContacts)
                .Include(s => s.DisabilityDetails)
                .Include(s => s.ParentGuardians)
                .Include(s => s.AcademicHistories)
                .Include(s => s.ExtracurricularDetails)
                .Include(s => s.Documents)
                .FirstOrDefaultAsync(s => s.Pid == pid);

            if (student == null)
                throw new KeyNotFoundException($"Student with Pid {pid} not found");

            return _mapper.Map<CompleteResponseDTO>(student);
        }

        public async Task<List<CompleteResponseDTO>> GetAllStudentsAsync()
        {
            var students = await _unitOfWork.Students.GetQueryable()
                .Include(s => s.PersonalDetails)
                .Include(s => s.ContactDetail)
                .Include(s => s.FinancialDetail)
                .Include(s => s.BankDetail)
                .Include(s => s.CitizenshipDetail)
                .Include(s => s.AcademicEnrollment)
                .Include(s => s.Declaration)
                .Include(s => s.Addresses)
                .Include(s => s.EmergencyContacts)
                .Include(s => s.DisabilityDetails)
                .Include(s => s.ParentGuardians)
                .Include(s => s.AcademicHistories)
                .Include(s => s.ExtracurricularDetails)
                .Include(s => s.Documents)
                .ToListAsync();

            return _mapper.Map<List<CompleteResponseDTO>>(students);
        }

        public async Task DeleteStudentAsync(Guid pid)
        {
            var student = await _unitOfWork.Students.GetQueryable()
                .Include(s => s.Documents)
                .Include(s => s.AcademicHistories)
                .FirstOrDefaultAsync(s => s.Pid == pid);

            if (student == null)
                throw new KeyNotFoundException($"Student with Pid {pid} not found");

            // ✅ Delete associated files
            if (!string.IsNullOrEmpty(student.PhotoPath))
            {
                await _fileService.DeleteFileAsync(student.PhotoPath);
            }

            if (student.Documents != null)
            {
                foreach (var doc in student.Documents)
                {
                    await _fileService.DeleteFileAsync(doc.FilePath);
                }
            }

            if (student.AcademicHistories != null)
            {
                foreach (var history in student.AcademicHistories)
                {
                    if (!string.IsNullOrEmpty(history.MarksheetPath))
                    {
                        await _fileService.DeleteFileAsync(history.MarksheetPath);
                    }
                }
            }

            _unitOfWork.Students.Remove(student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CompleteResponseDTO> UpdateStudentAsync(Guid pid, CompleteRequestDTO dto)
        {
            var student = await _unitOfWork.Students.GetQueryable()
                .Include(s => s.PersonalDetails)
                .Include(s => s.ContactDetail)
                .Include(s => s.FinancialDetail)
                .Include(s => s.BankDetail)
                .Include(s => s.CitizenshipDetail)
                .Include(s => s.AcademicEnrollment)
                .Include(s => s.Declaration)
                .Include(s => s.Addresses)
                .Include(s => s.EmergencyContacts)
                .Include(s => s.DisabilityDetails)
                .Include(s => s.ParentGuardians)
                .Include(s => s.AcademicHistories)
                .Include(s => s.ExtracurricularDetails)
                .Include(s => s.Documents)
                .FirstOrDefaultAsync(s => s.Pid == pid);

            if (student == null)
                throw new KeyNotFoundException($"Student with Pid {pid} not found");

            var now = DateTime.UtcNow;

            // Map DTO to existing student (updates all simple properties)
            _mapper.Map(dto, student);
            student.UpdatedOn = now;

            // Update one-to-one relationships
            if (student.PersonalDetails != null)
            {
                _mapper.Map(dto, student.PersonalDetails);
                student.PersonalDetails.UpdatedOn = now;
            }

            if (student.ContactDetail != null)
            {
                _mapper.Map(dto, student.ContactDetail);
                student.ContactDetail.UpdatedOn = now;
            }

            if (student.FinancialDetail != null)
            {
                _mapper.Map(dto, student.FinancialDetail);
                student.FinancialDetail.UpdatedOn = now;
            }

            if (student.BankDetail != null)
            {
                _mapper.Map(dto, student.BankDetail);
                student.BankDetail.UpdatedOn = now;
            }

            if (student.CitizenshipDetail != null)
            {
                _mapper.Map(dto, student.CitizenshipDetail);
                student.CitizenshipDetail.UpdatedOn = now;
            }

            if (student.AcademicEnrollment != null)
            {
                _mapper.Map(dto, student.AcademicEnrollment);
                student.AcademicEnrollment.UpdatedOn = now;
            }

            if (student.Declaration != null)
            {
                _mapper.Map(dto, student.Declaration);
                student.Declaration.UpdatedOn = now;
            }

            // Update collections (clear and re-add)
            student.Addresses?.Clear();
            if (dto.Addresses != null)
            {
                student.Addresses = _mapper.Map<List<Address>>(dto.Addresses);
                foreach (var a in student.Addresses)
                {
                    a.StudentId = student.Id;
                } 
            }

            student.EmergencyContacts?.Clear();
            if (dto.EmergencyContacts != null)
            {
                student.EmergencyContacts = _mapper.Map<List<EmergencyContact>>(dto.EmergencyContacts);
                foreach (var c in student.EmergencyContacts)
                {
                    c.StudentId = student.Id;
                } 
            }

            student.DisabilityDetails?.Clear();
            if (dto.DisabilityDetails != null)
            {
                student.DisabilityDetails = _mapper.Map<List<DisabilityDetail>>(dto.DisabilityDetails);
                foreach (var d in student.DisabilityDetails)
                {
                    d.StudentId = student.Id;
                } 
            }

            student.ParentGuardians?.Clear();
            if (dto.ParentGuardians != null)
            {
                student.ParentGuardians = _mapper.Map<List<ParentGuardian>>(dto.ParentGuardians);
                foreach (var p in student.ParentGuardians)
                {
                    p.StudentId = student.Id;
                }
            }

            student.AcademicHistories?.Clear();
            if (dto.AcademicHistories != null)
            {
                student.AcademicHistories = _mapper.Map<List<AcademicHistory>>(dto.AcademicHistories);
                foreach (var h in student.AcademicHistories)
                {
                    h.StudentId = student.Id;
                }
            }

            student.ExtracurricularDetails?.Clear();
            if (dto.ExtracurricularDetails != null)
            {
                student.ExtracurricularDetails = _mapper.Map<List<ExtracurricularDetail>>(dto.ExtracurricularDetails);
                foreach (var e in student.ExtracurricularDetails)
                {
                    e.StudentId = student.Id;
                }
            }           

            student.Documents?.Clear();
            if (dto.Documents != null)
            {
                student.Documents = _mapper.Map<List<StudentDocument>>(dto.Documents);
                foreach (var doc in student.Documents)
                {
                    doc.StudentId = student.Id;
                } 
            }

            _unitOfWork.Students.Update(student);
            await _unitOfWork.SaveChangesAsync();

            return await GetStudentByIdAsync(student.Id);
        }

        // ✅✅✅ SMART FILE UPLOAD METHOD
        public async Task<CompleteResponseDTO> UploadStudentFilesAsync(Guid pid, StudentFileUploadDTO fileDto)
        {
            var student = await _unitOfWork.Students.GetQueryable()
                .Include(s => s.Documents)
                .Include(s => s.AcademicHistories)
                .Include(s => s.PersonalDetails)
                .Include(s => s.ContactDetail)
                .Include(s => s.FinancialDetail)
                .Include(s => s.BankDetail)
                .Include(s => s.CitizenshipDetail)
                .Include(s => s.AcademicEnrollment)
                .Include(s => s.Declaration)
                .Include(s => s.Addresses)
                .Include(s => s.EmergencyContacts)
                .Include(s => s.DisabilityDetails)
                .Include(s => s.ParentGuardians)
                .Include(s => s.ExtracurricularDetails)
                .FirstOrDefaultAsync(s => s.Pid == pid);

            if (student == null)
                throw new KeyNotFoundException($"Student with Pid {pid} not found");

            // ✅ SMART LOGIC: Handle Student Photo Upload
            if (fileDto.PhotoFile != null)
            {
                // Delete old photo if exists and is a real file (not empty string)
                if (!string.IsNullOrEmpty(student.PhotoPath) && _fileService.FileExists(student.PhotoPath))
                {
                    await _fileService.DeleteFileAsync(student.PhotoPath);
                }
                
                // Upload new file and set path
                student.PhotoPath = await _fileService.SaveFileAsync(fileDto.PhotoFile, "Students/Photos");
            }
            // If no file uploaded, keep existing path (don't change it)

            // ✅ SMART LOGIC: Handle Signature Document
            if (fileDto.SignatureFile != null)
            {
                // Remove old signature document if exists
                var oldSignature = student.Documents?.FirstOrDefault(d => d.DocumentType == DocumentType.Signature);
                if (oldSignature != null)
                {
                    if (_fileService.FileExists(oldSignature.FilePath))
                    {
                        await _fileService.DeleteFileAsync(oldSignature.FilePath);
                    }
                    student.Documents.Remove(oldSignature);
                }

                // Upload new file and create document
                var signaturePath = await _fileService.SaveFileAsync(fileDto.SignatureFile, "Documents/Signatures");
                student.Documents ??= new List<StudentDocument>();
                student.Documents.Add(new StudentDocument
                {
                    StudentId = student.Id,
                    DocumentType = DocumentType.Signature,
                    FilePath = signaturePath
                });
            }

            // ✅ SMART LOGIC: Handle Citizenship Document
            if (fileDto.CitizenshipFile != null)
            {
                var oldCitizenship = student.Documents?.FirstOrDefault(d => d.DocumentType == DocumentType.Citizenship);
                if (oldCitizenship != null)
                {
                    if (_fileService.FileExists(oldCitizenship.FilePath))
                    {
                        await _fileService.DeleteFileAsync(oldCitizenship.FilePath);
                    }
                    student.Documents.Remove(oldCitizenship);
                }

                var citizenshipPath = await _fileService.SaveFileAsync(fileDto.CitizenshipFile, "Documents/Citizenship");
                student.Documents ??= new List<StudentDocument>();
                student.Documents.Add(new StudentDocument
                {
                    StudentId = student.Id,
                    DocumentType = DocumentType.Citizenship,
                    FilePath = citizenshipPath
                });
            }

            // ✅ SMART LOGIC: Handle Character Certificate Document
            if (fileDto.CharacterCertificateFile != null)
            {
                var oldCert = student.Documents?.FirstOrDefault(d => d.DocumentType == DocumentType.CharacterCertificate);
                if (oldCert != null)
                {
                    if (_fileService.FileExists(oldCert.FilePath))
                    {
                        await _fileService.DeleteFileAsync(oldCert.FilePath);
                    }
                    student.Documents.Remove(oldCert);
                }

                var certPath = await _fileService.SaveFileAsync(fileDto.CharacterCertificateFile, "Documents/CharacterCertificates");
                student.Documents ??= new List<StudentDocument>();
                student.Documents.Add(new StudentDocument
                {
                    StudentId = student.Id,
                    DocumentType = DocumentType.CharacterCertificate,
                    FilePath = certPath
                });
            }

            // ✅ SMART LOGIC: Handle Marksheet Files (for Academic Histories)
            if (fileDto.MarksheetFiles != null && fileDto.MarksheetFiles.Any())
            {
                var academicHistories = student.AcademicHistories?.OrderBy(a => a.Id).ToList();
                
                if (academicHistories != null)
                {
                    for (int i = 0; i < Math.Min(fileDto.MarksheetFiles.Count, academicHistories.Count); i++)
                    {
                        if (fileDto.MarksheetFiles[i] != null)
                        {
                            // Delete old marksheet if exists and is a real file
                            if (!string.IsNullOrEmpty(academicHistories[i].MarksheetPath) && 
                                _fileService.FileExists(academicHistories[i].MarksheetPath))
                            {
                                await _fileService.DeleteFileAsync(academicHistories[i].MarksheetPath);
                            }

                            // Upload new file and set path
                            var marksheetPath = await _fileService.SaveFileAsync(
                                fileDto.MarksheetFiles[i], 
                                "AcademicHistories/Marksheets"
                            );
                            academicHistories[i].MarksheetPath = marksheetPath;
                        }
                        // If no file uploaded for this index, keep existing path
                    }
                }
            }

            student.UpdatedOn = DateTime.UtcNow;
            _unitOfWork.Students.Update(student);
            await _unitOfWork.SaveChangesAsync();

            return await GetStudentByIdAsync(student.Id);
        }
    }
}
