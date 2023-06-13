using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryTransferencia
    {
        protected DBContext db;

        public RepositoryTransferencia(DBContext context)
        {
            this.db = context;
        }
    }
}
