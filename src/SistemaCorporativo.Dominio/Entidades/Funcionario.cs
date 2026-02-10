using System;

namespace SistemaCorporativo.Dominio.Entidades
{
    public class Funcionario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public decimal Salario { get; private set; }
        public DateTime DataAdimissao { get; private set; }
        public Cargo cargo { get; private set; } // propriedade
        public bool Ativo { get; private set; }

        protected Funcionario() { }

        public Funcionario(string nome, string email, decimal salario, Cargo cargo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Salario = salario;
            this.cargo = cargo;
            DataAdimissao = DateTime.Now;
            Ativo = true;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("Insira o nome do funcionário!");
            if (string.IsNullOrWhiteSpace(Email))
                throw new ArgumentException("Insira o email!");
            if (!Email.Contains("@"))
                throw new ArgumentException("Email inválido!");
            if (Salario <= 0)
                throw new ArgumentException("Salário inválido!");
            if (cargo == null) // ✅ usar a propriedade 'cargo' minúscula
                throw new ArgumentException("Insira o cargo do funcionário!");
        }

        public void AtualizarSalario(decimal novoSalario)
        {
            if (novoSalario <= 0)
                throw new ArgumentException("Salário inválido!");
            Salario = novoSalario;
        }

        public void TrocarCargo(Cargo novoCargo)
        {
            if (novoCargo == null)
                throw new ArgumentException("Cargo inválido!");

            cargo = novoCargo; // ✅ usar a propriedade 'cargo' minúscula
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
