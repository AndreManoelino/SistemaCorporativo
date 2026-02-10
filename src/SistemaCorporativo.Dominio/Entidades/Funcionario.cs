using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace SistemaCorporativo.Dominio.Entidades
{
    public class Funcionario
    {
        public Guid Id{get; private set;}
        public string Nome{get; private set;}

        public string Email{get; private set;}

        public decimal Salario {get; private set;}

        public Datetime DataAdimissao {get; private set;}

        public Cargo cargo{get; private set;}

        public bool Ativo {get; private set;}

        protected Funcionario() {}

        public Funcionario(string nome, string email, decimal salario, Cargo cargo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Salario = salario;
            Cargo = cargo;
            DataAdimissao = DateTime.Now;
            Ativo = true;

            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("Inisira o nome do funcoinário!");
            if (string.IsNullOrWhiteSpace(Email))
                throw new ArgumentException("Insira o email ! ");
            if (!Email.Contains("@"))
                throw new ArgumentException("Email inválido !");
            
            if (Salario <= 0) throw new ArgumentException("Salario inválido! ");
            if (Cargo == null) throw new ArgumentException("Inisria o cargo do funcionário !");

        }
        public void AtualizarSalario(decimal novoSalario)
        {
            if (novoSalario <= 0) throw new ArgumentException("Salario inválido!");
            Salario = novoSalario;
        }

        public void TrocarCargo(Cargo novoCargo)
        {
            if (novoCargo == null) throw new ArgumentException("Cargo inválido!");

            Cargo = novoCargo;
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