using System.Globalization;
using sistemaCorporativo.Dominio.Entidades;

namespace SistemaCorporativo.Aplicacao.DTOs
{
    public class FuncionarioCriarDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public Cargo cargo { get; set; }
    }
}