using Microsoft.AspNetCore.Mvc;
using WebAppSample.Models;

namespace WebAppSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentaController : Controller
    {
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Cuenta> cuentas= new()
            {
                new Cuenta()
                {
                    Id= 1,
                    NumeroCuenta=3001,
                    Saldo=125,
                },
                new Cuenta()
                {
                    Id= 1,
                    NumeroCuenta=3002,
                    Saldo=150,
                },
                new Cuenta()
                {
                    Id= 1,
                    NumeroCuenta=3003,
                    Saldo=200,
                }
            };
            return Ok(cuentas);
            //return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create()
        {
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
            if(Id == null)
                return NotFound();
            return Ok();
        }
    }
}
