using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WebAppSample.Models;

namespace Infrastructure
{
    public class ModelConfigurations
    {
        public ModelConfigurations(DbModelBuilder builder)
        {
            #region CuentaConfig
            builder.Entity<Cuenta>()
               .Property(e => e.Id).IsRequired();
            builder.Entity<Cuenta>()
               .Property(e => e.NumeroCuenta).IsRequired();
            builder.Entity<Cuenta>()
               .Property(e => e.Saldo).IsRequired();
            #endregion

            #region TransferenciaConfig
            builder.Entity<Transferencia>()
               .Property(e => e.Id).IsRequired();
            builder.Entity<Transferencia>()
               .Property(e => e.IdCuentaOrigen).IsRequired();
            builder.Entity<Transferencia>()
               .Property(e => e.IdCuentaDestino).IsRequired();
            builder.Entity<Transferencia>()
               .Property(e => e.Monto).IsRequired();
            builder.Entity<Transferencia>()
               .Property(e => e.Motivo).IsRequired().HasMaxLength(100);
            #endregion
        }
    }
}
