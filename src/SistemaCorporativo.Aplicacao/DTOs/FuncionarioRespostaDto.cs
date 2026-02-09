using SistemaCorporativo.Dominio.Entidades;
namespace SistemaCorporativo.Aplicacao.DTOs
{
    public class FuncionarioRespostaDto
    {
        public Guid Id {get; set;}
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public Cargo cargo { get; set; }

        public bool Ativo { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}