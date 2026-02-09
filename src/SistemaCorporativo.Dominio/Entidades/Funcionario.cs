using System;

namespace SistemaCorporativo.Dominio.Entidades
{
    public class Funcionario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public decimal Salario { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public Cargo Cargo { get; private set; }
        public bool Ativo { get; private set; }

        protected Funcionario() { } // Necessário para EF

        public Funcionario(string nome, string email, decimal salario, Cargo cargo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Salario = salario;
            DataAdmissao = DateTime.Now;
            Cargo = cargo;
            Ativo = true;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("O nome do funcionário é obrigatório.");

            if (string.IsNullOrWhiteSpace(Email))
                throw new ArgumentException("O e-mail do funcionário é obrigatório.");

            if (Salario <= 0)
                throw new ArgumentException("O salário deve ser maior que zero.");
        }

        public void AtualizarSalario(decimal novoSalario)
        {
            if (novoSalario <= 0)
                throw new ArgumentException("O salário informado é inválido.");

            Salario = novoSalario;
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
