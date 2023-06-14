using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts.IRepositories
{
    public interface IRepositoryCuenta
    {
        Task<List<Cuenta>> GetAllCuentasAsync();
        Task<Cuenta> GetCuentaByIdAsync(long Id);
        void InsertCuenta(Cuenta model);
        void UpdateCuenta(Cuenta model);
    }
}
