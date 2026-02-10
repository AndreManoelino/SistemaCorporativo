using System;

namespace SistemaCorporativo.Aplicacao.DTOs
{
    public class FuncionarioCriarDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
        public Guid CargoId { get; set; }
    }
}
