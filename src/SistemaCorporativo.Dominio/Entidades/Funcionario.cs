using System.Globalization;

namespace SistemaCorporativo.Dominio.Entidades
{
    public class Funcionario
    {
        public Guid Id {get; private set;}
        public string Nome {get; private set;}
        public string Email{get; private set;}
        public decimal Salario {get; private set;}

        public DateTime DataAdmissao {get; private set;}

        public Cargo cargo{get; private set;}

        public bool Ativo {get; private set;}

        protected Funcionario() {} // Protegendo o contrutor

        public Funcionario (string nome, string email, decimal salario , Cargo cargo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Salario = salario;
            DataAdmissao = DateTime.Now;
            this.cargo = cargo;
            Ativo = true;
            Validar();
        }

        private void Validar()
        {
            if(string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("O nome do funcionário é obrigatório!");
            
            if(string.IsNullOrWhiteSpace(Email))
                throw new ArgumentException("O email do funcionário é obrigatório!");
            if(Salario <= 0)
                throw new ArgumentException("O salário do funcionário deve ser maior que zero!");
        }

        public void AtualizarSalario(decimal novoSalario)
        {
            if(novoSalario <= 0)
                throw new ArgumentException("O salário inválido!");
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