using Infrastructure.Contracts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        //Dependency injection
        private readonly ApplicationContext db;
        private RepositoryCuenta? repositoryCuenta;
        private RepositoryTransferencia? repositoryTransferencia;
        public UnitOfWork(ApplicationContext db)
        {
            this.db = db;
        }

        public RepositoryCuenta RepositoryCuenta
        {
            get
            {
                if (repositoryCuenta is null)
                    repositoryCuenta = new RepositoryCuenta(db);
                return repositoryCuenta;

            }
        }

        public RepositoryTransferencia RepositoryTransferencia
        {
            get
            {
                if(repositoryTransferencia is null)
                    repositoryTransferencia = new RepositoryTransferencia(db);
                return repositoryTransferencia;
            }
        }

        public void Dispose() => db.Dispose();
        public int SaveChange() => db.SaveChanges();
        public async Task<int> SaveChangeAsync() => 
            await db.SaveChangesAsync();

        public async Task<IDbContextTransaction> TransactionAsync() =>
             await db.Database.BeginTransactionAsync();
    }
}
