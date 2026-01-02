using StudentRegistrationForm.Interfaces.RepositoryInterfaces;
using StudentRegistrationForm.Models;

namespace StudentRegistrationForm.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IGenericRepository<Student> Students { get; }
        IGenericRepository<PersonalDetails> PersonalDetails { get; }
        IGenericRepository<ContactDetail> ContactDetails { get; }
        IGenericRepository<ParentGuardian> ParentGuardians { get; }
        IGenericRepository<EmergencyContact> EmergencyContacts { get; }
        IGenericRepository<Address> Addresses { get; }
        IGenericRepository<DisabilityDetail> DisabilityDetails { get; }
        IGenericRepository<FinancialDetail> FinancialDetails { get; }
        IGenericRepository<BankDetail> BankDetails { get; }
        IGenericRepository<CitizenshipDetail> CitizenshipDetails { get; }
        IGenericRepository<AcademicHistory> AcademicHistories { get; }
        IGenericRepository<AcademicEnrollment> AcademicEnrollments { get; }
        IGenericRepository<ExtracurricularDetail> ExtracurricularDetails { get; }
        IGenericRepository<StudentDocument> StudentDocuments { get; }
        IGenericRepository<Declaration> Declarations { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        Task ExecuteTransactionAsync(Action action, CancellationToken cancellationToken = default);
        Task ExecuteTransactionAsync(Func<Task> action, CancellationToken cancellationToken = default);
    }
}
