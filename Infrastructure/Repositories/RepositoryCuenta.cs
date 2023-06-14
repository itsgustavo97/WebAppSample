using Infrastructure.Contracts.IRepositories;

namespace Infrastructure.Repositories
{
    public class RepositoryCuenta : IRepositoryCuenta
    {
        private ApplicationContext db;

        public RepositoryCuenta(ApplicationContext context)
        {
            this.db = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
