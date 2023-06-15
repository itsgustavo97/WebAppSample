using Infrastructure.Contracts.IRepositories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private ApplicationContext db;
        public RepositoryCliente(ApplicationContext context)
        {
            this.db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            var clientes = await db.Cliente.ToListAsync();
            return clientes;
        }

        public void Insert(Cliente model)
        {
            db.Cliente.Add(model);
        }

        public void Update(Cliente model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

        public void Delete(Cliente model)
        {
            db.Cliente.Remove(model);
        }

        public async Task<Cliente> GetByIdAsync(long? Id)
        {
            var cliente = await db.Cliente.FindAsync(Id);
            return cliente ?? throw new Exception();
        }
    }
}
