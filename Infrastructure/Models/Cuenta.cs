namespace Infrastructure.Models
{
    public class Cuenta
    {
        public long Id { get; set; }
        public long NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }

        //public ICollection<Transferencia>? Transferencias { get; set; }
    }
}
