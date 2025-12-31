using StudentRegistrationForm.DTOs.RequestDTOs;
using StudentRegistrationForm.DTOs.ResponseDTOs;
using StudentRegistrationForm.Interfaces;
using StudentRegistrationForm.Interfaces.ServiceInterface;
using StudentRegistrationForm.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace StudentRegistrationForm.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompleteResponseDTO> AddStudentAsync(CompleteRequestDTO dto)
        {
            // 🎉 ONE LINE instead of 200+ lines!
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

            // 🎉 ONE LINE instead of 150+ lines!
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

            // 🎉 ONE LINE instead of Select + 150 lines!
            return _mapper.Map<List<CompleteResponseDTO>>(students);
        }

        public async Task DeleteStudentAsync(Guid pid)
        {
            var student = await _unitOfWork.Students.GetQueryable()
                .FirstOrDefaultAsync(s => s.Pid == pid);

            if (student == null)
                throw new KeyNotFoundException($"Student with Pid {pid} not found");

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
    }
}
