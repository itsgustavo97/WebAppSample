using Infrastructure.Contracts;
using Infrastructure.Repositories;
using System.Data.Entity;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        //Dependency injection
        private readonly DBContext db;

        private RepositoryCuenta? repositoryCuenta;
        private RepositoryTransferencia? repositoryTransferencia;
        public UnitOfWork(DBContext db)
        {
            this.db = db;
        }

        public RepositoryCuenta RepositoryCuenta =>
            repositoryCuenta == null ? new RepositoryCuenta(db) : repositoryCuenta;

        public RepositoryTransferencia RepositoryTransferencia =>
            repositoryTransferencia == null ? new RepositoryTransferencia(db) : repositoryTransferencia;

        public void Dispose() => db.Dispose();
        public int SaveChange() => db.SaveChanges();
        public async Task<int> SaveChangeAsync() => await db.SaveChangesAsync();
        public DbContextTransaction BeginTransaction() => db.Database.BeginTransaction();
    }
}
