using SistemaCorporativo.Aplicacao.DTOs;
using SistemaCorporativo.Aplicacao.Interfaces;
using SistemaCorporativo.Dominio.Entidades;
using SistemaCorporativo.Dominio.Interfaces;

namespace SistemaCorporativo.Aplicacao.Servicos
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ICargoRepository _cargoRepository;

        public FuncionarioService(
            IFuncionarioRepository funcionarioRepository,
            ICargoRepository cargoRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _cargoRepository = cargoRepository;
        }

        public async Task<FuncionarioRespostaDto> CriarAsync(FuncionarioCriarDto dto)
        {
            var cargo = await _cargoRepository.ObterPorIdAsync(dto.CargoId)
                ?? throw new Exception("Cargo não encontrado.");

            var funcionario = new Funcionario(
                dto.Nome,
                dto.Email,
                dto.Salario,
                cargo
            );

            await _funcionarioRepository.AdicionarAsync(funcionario);

            return Mapear(funcionario);
        }

        public async Task<IEnumerable<FuncionarioRespostaDto>> ListarAsync()
        {
            var funcionarios = await _funcionarioRepository.ObterTodosAsync();
            return funcionarios.Select(Mapear);
        }

        public async Task<FuncionarioRespostaDto?> ObterPorIdAsync(Guid id)
        {
            var funcionario = await _funcionarioRepository.ObterPorIdAsync(id);
            return funcionario == null ? null : Mapear(funcionario);
        }

        public async Task AtualizarSalarioAsync(Guid id, decimal novoSalario)
        {
            var funcionario = await _funcionarioRepository.ObterPorIdAsync(id)
                ?? throw new Exception("Funcionário não encontrado.");

            funcionario.AtualizarSalario(novoSalario);

            await _funcionarioRepository.AtualizarAsync(funcionario);
        }

        public async Task DesativarAsync(Guid id)
        {
            var funcionario = await _funcionarioRepository.ObterPorIdAsync(id)
                ?? throw new Exception("Funcionário não encontrado.");

            funcionario.Desativar();

            await _funcionarioRepository.AtualizarAsync(funcionario);
        }

        private static FuncionarioRespostaDto Mapear(Funcionario funcionario)
        {
            return new FuncionarioRespostaDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Email = funcionario.Email,
                Salario = funcionario.Salario,
                CargoId = funcionario.cargo.Id,
                CargoNome = funcionario.cargo.Nome,
                Ativo = funcionario.Ativo,
                DataAdmissao = funcionario.DataAdmissao
            };
        }
    }
}
