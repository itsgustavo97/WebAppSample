using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Transferencia
    {
        public long Id { get; set; }
        [Required]
        public long IdCuentaOrigen { get; set; }
        [Required]
        public long IdCuentaDestino { get; set; }
        [Required]
        public decimal Monto { get; set; }
        [Required]
        [StringLength(100)]
        public string? Motivo { get; set; }

        //public TransferenciasCuentas? TransferenciasCuentas { get; set; }
    }
}
