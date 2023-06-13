using Infrastructure.Contracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryCuenta : IRepositoryCuenta
    {
        protected DBContext db;

        public RepositoryCuenta(DBContext context)
        {
            this.db = context;
        }
    }
}
