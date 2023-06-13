namespace WebAppSample.Models
{
    public class Transferencia
    {
        public long Id { get; set; }
        public long IdCuentaOrigen { get; set; }
        public long IdCuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public string? Motivo { get; set; }
    }
}
