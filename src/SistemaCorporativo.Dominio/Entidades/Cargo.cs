using System;

namespace SistemaCorporativo.Dominio.Entidades
{
    public class Cargo
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }

        protected Cargo() { } // Necessário para EF futuramente

        public Cargo(string nome, string descricao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            Ativo = true;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("O nome do cargo é obrigatório.");

            if (Nome.Length < 3)
                throw new ArgumentException("O nome do cargo deve ter pelo menos 3 caracteres.");
        }

        public void AtualizarDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição do cargo é obrigatória.");

            Descricao = descricao;
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
