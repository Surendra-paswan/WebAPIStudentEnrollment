using AutoMapper;
using StudentRegistrationForm.DTOs.RequestDTOs;
using StudentRegistrationForm.DTOs.ResponseDTOs;
using StudentRegistrationForm.Models;

namespace StudentRegistrationForm.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var now = DateTime.UtcNow;

            // REQUEST DTO → ENTITY MAPPINGS
            
            // Main Student mapping with timestamp handling
            CreateMap<CompleteRequestDTO, Student>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.PersonalDetails, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.ContactDetail, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.FinancialDetail, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.BankDetail, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.CitizenshipDetail, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.AcademicEnrollment, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Declaration, opt => opt.MapFrom(src => src));

            // Nested object mappings
            CreateMap<CompleteRequestDTO, PersonalDetails>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<CompleteRequestDTO, ContactDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<CompleteRequestDTO, FinancialDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<CompleteRequestDTO, BankDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<CompleteRequestDTO, CitizenshipDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<CompleteRequestDTO, AcademicEnrollment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<CompleteRequestDTO, Declaration>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            // Collection mappings (Request DTOs → Entities)
            CreateMap<AddressDTO, Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<EmergencyContactDTO, EmergencyContact>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<DisabilityDetailDTO, DisabilityDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<ParentGuardianDTO, ParentGuardian>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<AcademicHistoryDTO, AcademicHistory>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<ExtracurricularDetailDTO, ExtracurricularDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<StudentDocumentDTO, StudentDocument>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.StudentId, opt => opt.Ignore())
                .ForMember(dest => dest.Student, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));

            //ENTITY → RESPONSE DTO MAPPINGS 
            
            CreateMap<Student, CompleteResponseDTO>();
            CreateMap<PersonalDetails, PersonalDetailsResponseDTO>();
            CreateMap<ContactDetail, ContactDetailResponseDTO>();
            CreateMap<FinancialDetail, FinancialDetailResponseDTO>();
            CreateMap<BankDetail, BankDetailResponseDTO>();
            CreateMap<CitizenshipDetail, CitizenshipDetailResponseDTO>();
            CreateMap<AcademicEnrollment, AcademicEnrollmentResponseDTO>();
            CreateMap<Declaration, DeclarationResponseDTO>();
            CreateMap<Address, AddressResponseDTO>();
            CreateMap<EmergencyContact, EmergencyContactResponseDTO>();
            CreateMap<DisabilityDetail, DisabilityDetailResponseDTO>();
            CreateMap<ParentGuardian, ParentGuardianResponseDTO>();
            CreateMap<AcademicHistory, AcademicHistoryResponseDTO>();
            CreateMap<ExtracurricularDetail, ExtracurricularDetailResponseDTO>();
            CreateMap<StudentDocument, StudentDocumentResponseDTO>();
        }
    }
}
