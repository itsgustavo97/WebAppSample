using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        RepositoryCuenta RepositoryCuenta { get; }
        RepositoryTransferencia RepositoryTransferencia { get; }
        Task<int> SaveChangeAsync();
        int SaveChange();
        Task<IDbContextTransaction> TransactionAsync();
    }
}
