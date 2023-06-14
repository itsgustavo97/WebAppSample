using Infrastructure.Contracts;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAppSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentaController : Controller
    {
        private IUnitOfWork unitOfWork;

        public CuentaController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var cuentas = await unitOfWork.RepositoryCuenta.GetAllCuentasAsync();
            //List<Cuenta> cuentas= new()
            //{
            //    new Cuenta()
            //    {
            //        Id= 1,
            //        NumeroCuenta=3001,
            //        Saldo=125,
            //    }
            //};
            return Ok(cuentas);
            //return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Cuenta model)
        {
            unitOfWork.RepositoryCuenta.InsertCuenta(model);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Cuenta model)
        {
            if (model.Id == null)
                return BadRequest();
            var cuentaUpdate = await unitOfWork.RepositoryCuenta.GetCuentaByIdAsync(model.Id);
            cuentaUpdate.NumeroCuenta = model.NumeroCuenta;
            cuentaUpdate.Saldo = model.Saldo;
            unitOfWork.RepositoryCuenta.UpdateCuenta(cuentaUpdate);
            return Ok();
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(long? Id)
        {
            if(Id == null)
                return BadRequest();

            return Ok();
        }
    }
}
