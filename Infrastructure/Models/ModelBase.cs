using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ModelBase
    {
        public bool Borrado { get; set; }
        public DateTime FechaCreado { get; set; } = DateTime.Now;
        public DateTime? FechaModificado { get; set; }
    }
}
