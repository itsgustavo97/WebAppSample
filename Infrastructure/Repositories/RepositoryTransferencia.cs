namespace Infrastructure.Repositories
{
    public class RepositoryTransferencia
    {
        private ApplicationContext db;

        public RepositoryTransferencia(ApplicationContext context)
        {
            this.db = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
