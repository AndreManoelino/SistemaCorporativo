using SistemaCorporativo.Aplicacao.DTOs;
using SistemaCorporativo.Aplicacao.Interfaces;
using SistemaCorporativo.Dominio.Entidades;
using SistemaCorporativo.Dominio.Interfaces;

namespace SistemaCorporativo.Aplicacao.Servicos
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<FuncionarioRespostaDto> CriarAsync(FuncionarioCriarDto dto)
        {
            var funcionario = new Funcionario(
                dto.Nome,
                dto.Email,
                dto.Salario,
                dto.Cargo
            );

            await _repository.AdicionarAsync(funcionario);

            return Mapear(funcionario);
        }

        public async Task<IEnumerable<FuncionarioRespostaDto>> ListarAsync()
        {
            var funcionarios = await _repository.ObterTodosAsync();
            return funcionarios.Select(Mapear);
        }

        public async Task<FuncionarioRespostaDto?> ObterPorIdAsync(Guid id)
        {
            var funcionario = await _repository.ObterPorIdAsync(id);
            return funcionario == null ? null : Mapear(funcionario);
        }

        public async Task AtualizarSalarioAsync(Guid id, decimal novoSalario)
        {
            var funcionario = await _repository.ObterPorIdAsync(id)
                ?? throw new Exception("Funcionário não encontrado.");

            funcionario.AtualizarSalario(novoSalario);

            await _repository.AtualizarAsync(funcionario);
        }

        public async Task DesativarAsync(Guid id)
        {
            var funcionario = await _repository.ObterPorIdAsync(id)
                ?? throw new Exception("Funcionário não encontrado.");

            funcionario.Desativar();

            await _repository.AtualizarAsync(funcionario);
        }

        private static FuncionarioRespostaDto Mapear(Funcionario funcionario)
        {
            return new FuncionarioRespostaDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Email = funcionario.Email,
                Salario = funcionario.Salario,
                Cargo = funcionario.Cargo,
                Ativo = funcionario.Ativo,
                DataAdmissao = funcionario.DataAdmissao
            };
        }
    }
}
