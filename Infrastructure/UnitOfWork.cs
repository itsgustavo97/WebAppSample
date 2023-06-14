using Infrastructure.Contracts;
using Infrastructure.Contracts.IRepositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        //Dependency injection
        private readonly ApplicationContext db;
        private IRepositoryCuenta? repositoryCuenta;
        private IRepositoryTransferencia? repositoryTransferencia;
        public UnitOfWork(ApplicationContext db)
        {
            this.db = db;
        }

        public IRepositoryCuenta RepositoryCuenta =>
            repositoryCuenta ??= new RepositoryCuenta(db);


        public IRepositoryTransferencia RepositoryTransferencia =>
            repositoryTransferencia ??= new RepositoryTransferencia(db);

        public void Dispose() => db.Dispose();
        public int SaveChange() => db.SaveChanges();
        public async Task<int> SaveChangeAsync() => 
            await db.SaveChangesAsync();

        public async Task<IDbContextTransaction> TransactionAsync() =>
             await db.Database.BeginTransactionAsync();
    }
}
