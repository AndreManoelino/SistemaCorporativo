using SistemaCorporativo.Dominio.Entidades;

namespace SistemaCorporativo.Aplicacao.Interfaces
{
    public interface IFuncionarioService
    {
        Task<FuncionarioRespostaDto> CriarAsync(FuncionarioCriarDto dto);
        Task<IEnumerable<FuncionarioRespostaDto>> ListarAsync();
        Task<FuncionarioRespostaDto?> ObterPorIdAsync(Guid id);
        Task AtualizarSalarioAsync(Guid id, decimal novoSalario);
        Task DesativarAsync(Guid id);

    }
}