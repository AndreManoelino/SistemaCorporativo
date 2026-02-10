using SistemaCorporativo.Dominio.Entidades;
using SistemaCorporativo.Dominio.Interfaces;

namespace SistemaCorporativo.Infraestrutura.Repositorios
{
    public class FuncionarioRepositoryMemoria : IFuncionarioRepository
    {
        private readonly List<Funcionario> _funcionarios = new List<Funcionario>();

        public Task AdicionarAsync(Funcionario funcionario)
        {
            _funcionarios.Add(funcionario);
            return Task.CompletedTask;
        }

        public Task AtualizarAsync(Funcionario funcionario)
        {
            // Como estamos em memória, nada extra precisa ser feito.
            return Task.CompletedTask;
        }

        public Task<Funcionario?> ObterPorIdAsync(Guid id)
        {
            var func = _funcionarios.FirstOrDefault(f => f.Id == id);
            return Task.FromResult(func);
        }

        public Task<IEnumerable<Funcionario>> ObterTodosAsync()
        {
            return Task.FromResult(_funcionarios.AsEnumerable());
        }
    }
}
