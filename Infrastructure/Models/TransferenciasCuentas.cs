using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class TransferenciasCuentas
    {
        [Required]
        public long IdCuenta { get; set; }
        [Required]
        public long IdTransferencia { get; set; }
    }
}
