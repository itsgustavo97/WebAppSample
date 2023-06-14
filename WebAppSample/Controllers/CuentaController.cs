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
            return Ok(cuentas);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Cuenta model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            unitOfWork.RepositoryCuenta.InsertCuenta(model);
            unitOfWork.SaveChange();
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
        public async Task<IActionResult> GetById(long? Id)
        {
            if(Id == null)
                return BadRequest();
            var cuenta = await unitOfWork.RepositoryCuenta.GetCuentaByIdAsync(Id);
            return Ok(cuenta);
        }
    }
}
