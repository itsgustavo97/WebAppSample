using System.Data.Entity;

namespace Infrastructure.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangeAsync();
        DbContextTransaction BeginTransaction();
        int SaveChange();
    }
}
