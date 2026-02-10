using Microsoft.AspNetCore.Mvc;
using SistemaCorporativo.Aplicacao.DTOs;
using SistemaCorporativo.Aplicacao.Interfaces;

namespace SistemaCorporativo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _service;

        public FuncionarioController(IFuncionarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioRespostaDto>> Criar(FuncionarioCriarDto dto)
        {
            var funcionario = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = funcionario.Id }, funcionario);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioRespostaDto>>> Listar()
        {
            var funcionarios = await _service.ListarAsync();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioRespostaDto>> ObterPorId(Guid id)
        {
            var funcionario = await _service.ObterPorIdAsync(id);
            if (funcionario == null) return NotFound();
            return Ok(funcionario);
        }
    }
}
