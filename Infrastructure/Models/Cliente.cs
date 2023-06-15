using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Cliente
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [StringLength(100)]
        [Required]
        public string? Apellido { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        [StringLength(200)]
        public string? Direccion { get; set; }

        [Required]
        public int NumeroTelefonico { get; set; }

        [Required]
        [StringLength(100)]
        public string? CorreoElectronico { get; set; }
    }
}
