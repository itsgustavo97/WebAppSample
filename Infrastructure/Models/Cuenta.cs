using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Cuenta
    {
        public long Id { get; set; }
        [Required]
        public long NumeroCuenta { get; set; }
        [Required]
        public decimal Saldo { get; set; }

        //public ICollection<Transferencia>? Transferencias { get; set; }
    }
}
