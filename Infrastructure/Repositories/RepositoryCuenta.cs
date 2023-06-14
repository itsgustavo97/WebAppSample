using Infrastructure.Contracts.IRepositories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RepositoryCuenta : IRepositoryCuenta
    {
        private ApplicationContext db;

        public RepositoryCuenta(ApplicationContext context)
        {
            this.db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Cuenta>> GetAllCuentasAsync()
        {
            var cuentas = await db.Cuenta.ToListAsync();
            return cuentas;
        }

        public void InsertCuenta(Cuenta model)
        {
            db.Cuenta.Add(model);
        }

        public void UpdateCuenta(Cuenta model)
        {
            db.Entry(model).State= EntityState.Modified;
        }

        public async Task<Cuenta> GetCuentaByIdAsync(long Id)
        {
            var cuenta = await db.Cuenta.FindAsync(Id);
            return cuenta ?? throw new Exception();
        }
    }
}
