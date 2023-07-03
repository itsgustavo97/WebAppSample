using Infrastructure.Contracts;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebAppSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private IUnitOfWork unitOfWork;

        public ClienteController(IUnitOfWork _unitOfWork)
        {
            unitOfWork= _unitOfWork;
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var clientes = await unitOfWork.RepositoryCliente.GetAllAsync();
            return Ok(clientes);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Cliente model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            unitOfWork.RepositoryCliente.Insert(model);
            return Ok(unitOfWork.SaveChange());
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Cliente model)
        {
            //model = JsonSerializer.Deserialize<Cliente>(model);
            if (model.Id == null)
                return BadRequest();
            var clienteUpdate = await unitOfWork.RepositoryCliente.GetByIdAsync(model.Id);
            clienteUpdate.Nombre = model.Nombre;
            clienteUpdate.Apellido = model.Apellido;
            clienteUpdate.Edad = model.Edad;
            clienteUpdate.Direccion = model.Direccion;
            clienteUpdate.NumeroTelefonico = model.NumeroTelefonico;
            clienteUpdate.CorreoElectronico = model.CorreoElectronico;
            unitOfWork.RepositoryCliente.Update(clienteUpdate);
            return Ok(unitOfWork.SaveChange());
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public async Task<IActionResult> GetById(long? Id)
        {
            if (Id == null)
                return BadRequest();
            var cliente = await unitOfWork.RepositoryCliente.GetByIdAsync(Id);
            return Ok(cliente);
        }
    }
}
