using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAppSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferenciaController : Controller
    {
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Transferencia> tranfers = new()
            {
                new Transferencia()
                {
                    Id= 1,
                    IdCuentaOrigen=1,
                    IdCuentaDestino=3,
                    Monto=25,
                    Motivo="Prestamo amistoso"
                },
                new Transferencia()
                {
                    Id= 2,
                    IdCuentaOrigen=3,
                    IdCuentaDestino=2,
                    Monto=25,
                    Motivo="Prestamo amistoso 2"
                }
            };
            return Ok(tranfers);
            //return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Transferencia transfer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cuentOrigen = GetById(transfer.IdCuentaOrigen);
            var cuentaDestino = GetById(transfer.IdCuentaDestino);

            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(long? Id)
        {
            if (Id == null)
                return NotFound();
            return Ok();
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(long? Id)
        {
            if (Id == null)
                return NotFound();
            return Ok();
        }
    }
}
