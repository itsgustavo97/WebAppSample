using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ModelConfigurations
    {
        public ModelConfigurations(ModelBuilder builder)
        {
            #region CuentaConfig
            builder.Entity<Cuenta>().Property(e => e.Id).IsRequired();
            builder.Entity<Cuenta>().Property(e => e.NumeroCuenta).IsRequired();
            builder.Entity<Cuenta>().Property(e => e.Saldo).IsRequired();
            //builder.Entity<Cuenta>().HasMany(e => e.Transferencias).WithOne(e => e.IdCuentaOrigen);
            #endregion

            #region TransferenciaConfig
            builder.Entity<Transferencia>().Property(e => e.Id).IsRequired();
            //builder.Entity<Transferencia>().HasOne(e => e.CuentaOrigen).WithOne(e => e.Id);
            builder.Entity<Transferencia>().Property(e => e.IdCuentaOrigen).IsRequired();
            builder.Entity<Transferencia>().Property(e => e.IdCuentaDestino).IsRequired();
            builder.Entity<Transferencia>().Property(e => e.Monto).IsRequired();
            builder.Entity<Transferencia>().Property(e => e.Motivo).IsRequired().HasMaxLength(100);
            #endregion

            #region ClienteConfig
            builder.Entity<Cliente>().Property(e => e.Id).IsRequired();
            builder.Entity<Cliente>().Property(e => e.Nombre).IsRequired();
            builder.Entity<Cliente>().Property(e => e.Apellido).IsRequired();
            builder.Entity<Cliente>().Property(e => e.Edad).IsRequired();
            builder.Entity<Cliente>().Property(e => e.Direccion).IsRequired();
            builder.Entity<Cliente>().Property(e => e.NumeroTelefonico).IsRequired();
            builder.Entity<Cliente>().Property(e => e.CorreoElectronico).IsRequired();
            #endregion
        }
    }
}
