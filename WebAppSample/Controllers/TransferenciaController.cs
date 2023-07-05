using Infrastructure.Contracts;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAppSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferenciaController : Controller
    {
        private IUnitOfWork unitOfWork;
        public TransferenciaController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var tranfers = await unitOfWork.RepositoryTransferencia.GetAllTransferenciasAsync();
            return Ok(tranfers);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Transferencia model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            unitOfWork.RepositoryTransferencia.InsertTransferencia(model);
            return Ok(await unitOfWork.SaveChangeAsync());
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Transferencia model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            unitOfWork.RepositoryTransferencia.UpdateCuenta(model);
            return Ok(await unitOfWork.SaveChangeAsync());
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public async Task<IActionResult> GetById(long? Id)
        {
            if (Id == null)
                return BadRequest();
            var transfer = await unitOfWork.RepositoryTransferencia.GetTransferenciaByIdAsync(Id);
            return Ok(transfer);
        }

        [HttpPost]
        [Route("TransaccionAsync")]
        public async Task<IActionResult> Transaccion(Transferencia model)
        {
            using (var transac = await unitOfWork.TransactionAsync())
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var cuentaOrigen = await unitOfWork.RepositoryCuenta.GetCuentaByIdAsync(model.IdCuentaOrigen);
                    cuentaOrigen.Saldo = cuentaOrigen.Saldo - model.Monto;
                    unitOfWork.RepositoryCuenta.UpdateCuenta(cuentaOrigen);
                    await unitOfWork.SaveChangeAsync();

                    var cuentaDestino = await unitOfWork.RepositoryCuenta.GetCuentaByIdAsync(model.IdCuentaDestino);
                    cuentaDestino.Saldo = cuentaDestino.Saldo + model.Monto;
                    unitOfWork.RepositoryCuenta.UpdateCuenta(cuentaDestino);
                    await unitOfWork.SaveChangeAsync();

                    unitOfWork.RepositoryTransferencia.InsertTransferencia(model);
                    await unitOfWork.SaveChangeAsync();
                    await transac.CommitAsync();
                    return Ok(true);
                }
                catch (Exception ex)
                {
                    await transac.RollbackAsync();
                    return BadRequest(ex);
                }
            }
        }
    }
}
