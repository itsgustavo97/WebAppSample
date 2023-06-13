using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppSample.Models;

namespace Infrastructure
{
    public class DBContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            new ModelConfigurations(modelBuilder);
        }

        public DbSet<Cuenta>? Cuenta { get; set; }
        public DbSet<Transferencia>? Transferencia { get; set; }

    }
}
