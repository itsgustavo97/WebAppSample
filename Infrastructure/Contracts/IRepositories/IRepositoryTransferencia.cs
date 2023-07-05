using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts.IRepositories
{
    public interface IRepositoryTransferencia
    {
        Task<List<Transferencia>> GetAllTransferenciasAsync();
        Task<Transferencia> GetTransferenciaByIdAsync(long? Id);
        void InsertTransferencia(Transferencia model);
        void UpdateTransferencia(Transferencia model);
    }
}
