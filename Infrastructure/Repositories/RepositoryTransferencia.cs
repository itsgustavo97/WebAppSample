using Infrastructure.Contracts.IRepositories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RepositoryTransferencia : IRepositoryTransferencia
    {
        private ApplicationContext db;

        public RepositoryTransferencia(ApplicationContext context)
        {
            this.db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Transferencia>> GetAllTransferenciasAsync()
        {
            var tranfers = await db.Transferencia.ToListAsync();
            return tranfers;
        }

        public void InsertTransferencia(Transferencia model)
        {
            db.Transferencia.Add(model);
        }

        public void UpdateCuenta(Transferencia model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

        public async Task<Transferencia> GetTransferenciaByIdAsync(long? Id)
        {
            var transfer = await db.Transferencia.FindAsync(Id);
            return transfer ?? throw new Exception();
        }
    }
}
