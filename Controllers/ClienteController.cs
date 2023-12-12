using Entities;
using Desafio.Repositories;
using Microsoft.AspNetCore.Mvc;

//Cliente Controller

namespace Desafio.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService clienteService;
        
        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet("getclientelist")]
        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await clienteService.GetClienteListAsync();
        }

        [HttpGet("getclientebyid")]
        public async Task<IEnumerable<Cliente>> GetClienteByIdAsync(int Id)
        {
            var response = await clienteService.GetClienteByIdAsync(Id);

            if(Response == null)
            {
                return null;
            }
            return response;
        }

        [HttpPost("addcliente")]
        public async Task<IActionResult> AddClienteAsync(Cliente cliente)
        {
            if(cliente == null)
            {
                return BadRequest();
            }
            var response = await clienteService.AddClienteAsync(cliente);
            return Ok(response);
        }

        [HttpPut("updatecliente")]
        public async Task<IActionResult> UpdateClienteAsync(Cliente cliente)
        {
            if(cliente == null)
            {
                return BadRequest();
            }
            var result = await clienteService.UpdateClienteAsync(cliente);
            return Ok(result);
        }
        [HttpDelete("deletecliente")]
        public async Task<int> DeleteClienteAsync(int Id)
        {
            var response = await clienteService.DeleteClienteAsync(Id);
            return response;
        }
    }
 }