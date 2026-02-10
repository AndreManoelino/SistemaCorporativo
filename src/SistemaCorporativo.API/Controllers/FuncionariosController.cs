using Microsoft.AspNetCore.Mvc;
using SistemaCorporativo.Aplicacao.DTOs;
using SistemaCorporativo.Aplicacao.Interfaces;
using SistemaCorporativo.Aplicacao.Services;
using System;
using System.Collections.Generic;

namespace SistemaCorporativo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionariosController()
        {
            // Como não temos injeção de dependência configurada, instanciamos direto
            _funcionarioService = new FuncionarioService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<FuncionarioRespostaDto>> Listar()
        {
            var funcionarios = _funcionarioService.Listar();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public ActionResult<FuncionarioRespostaDto> ObterPorId(Guid id)
        {
            var funcionario = _funcionarioService.ObterPorId(id);
            if (funcionario == null) return NotFound();
            return Ok(funcionario);
        }

        [HttpPost]
        public ActionResult<FuncionarioRespostaDto> Criar([FromBody] FuncionarioCriarDto dto)
        {
            try
            {
                var funcionario = _funcionarioService.Criar(dto);
                return CreatedAtAction(nameof(ObterPorId), new { id = funcionario.Id }, funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] FuncionarioRespostaDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { mensagem = "ID do funcionário não confere!" });

            try
            {
                _funcionarioService.Atualizar(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _funcionarioService.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
