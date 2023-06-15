using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts.IRepositories
{
    public interface IRepositoryCliente
    {
        void Delete(Cliente model);
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(long? Id);
        void Insert(Cliente model);
        void Update(Cliente model);
    }
}
