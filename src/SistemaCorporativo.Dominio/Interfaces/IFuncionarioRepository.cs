using SistemaCorporativo.Dominio.Entidades;

namespace SistemaCorporativo.Dominio.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task AdicionarAsync(Funcionario funcionario);
        Task AtualizarAsync(Funcionario funcionario);
        Task<Funcionario?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Funcionario>> ObterTodosAsync();
    }
}
