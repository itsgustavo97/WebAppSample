using Infrastructure.Contracts.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryCliente RepositoryCliente { get; }
        IRepositoryCuenta RepositoryCuenta { get; }
        IRepositoryTransferencia RepositoryTransferencia { get; }
        Task<int> SaveChangeAsync();
        int SaveChange();
        Task<IDbContextTransaction> TransactionAsync();
    }
}
