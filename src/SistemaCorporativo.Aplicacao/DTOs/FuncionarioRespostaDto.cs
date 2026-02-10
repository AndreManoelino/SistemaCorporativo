using System;

namespace SistemaCorporativo.Aplicacao.DTOs
{
    public class FuncionarioRespostaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
        public string CargoNome { get; set; }
        public bool Ativo { get; set; }
    }
}
