using Infrastructure.Contracts.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryCuenta RepositoryCuenta { get; }
        IRepositoryTransferencia RepositoryTransferencia { get; }
        Task<int> SaveChangeAsync();
        int SaveChange();
        Task<IDbContextTransaction> TransactionAsync();
    }
}
