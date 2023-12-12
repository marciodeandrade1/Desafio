using Desafio.Repositories;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogradouroController : Controller
    {
        private readonly ILogradouroService logradouroService;
        public LogradouroController(ILogradouroService logradouroService)
        {
            this.logradouroService = logradouroService;
        }

        [HttpGet("getlogradourolist")]
        public async Task<List<Logradouro>> GetLogradourosAsync()
        {
            return await logradouroService.GetLogradouroListAsync();
        }

        [HttpGet("getlogradourobyid")]
        public async Task<IEnumerable<Logradouro>> GetLogradouroByIdAsync(int Id)
        {
            var response = await logradouroService.GetLogradouroByIdAsync(Id);

            if (Response == null)
            {
                return null;
            }
            return response;
        }

        [HttpPost("addlogradouro")]
        public async Task<IActionResult> AddLogradouroAsync(Logradouro logradouro)
        {
            if (logradouro == null)
            {
                return BadRequest();
            }
            var response = await logradouroService.AddLogradouroAsync(logradouro);
            return Ok(response);
        }

        [HttpPut("updatelogradouro")]
        public async Task<IActionResult> UpdateLogradouroAsync(Logradouro logradouro)
        {
            if (logradouro == null)
            {
                return BadRequest();
            }
            var result = await logradouroService.UpdateLogradouroAsync(logradouro);
            return Ok(result);
        }
        [HttpDelete("deletelogradouro")]
        public async Task<int> DeleteLogradouroAsync(int Id)
        {
            var response = await logradouroService.DeleteLogradouroAsync(Id);
            return response;
        }
    }
}
