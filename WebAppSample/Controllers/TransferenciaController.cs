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
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var tranfers = await unitOfWork.RepositoryTransferencia.GetAllTransferenciasAsync();
            return Ok(tranfers);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Transferencia transfer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
