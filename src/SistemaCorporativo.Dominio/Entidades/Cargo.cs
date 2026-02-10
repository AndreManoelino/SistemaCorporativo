
namespace SistemaCorporativo.Dominio.Entidades
{
    public class Cargo
    {
        public Guid Id {get; private set;}
        public string Nome{get; private set;}
        public string Descricao{get; private set;}

        public bool Ativo{get; private set;}

        protected Cargo(){}

        public Cargo(string nome, string descricao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            Ativo = true;
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("O nome do cargo é obrigátorio!");
            if (string.IsNullWhiteSpace(Descricao))
                throw new ArgumentException("A descrição do cargo é obrigatoria!");
        }

        public void AtualizarDescricao(string novaDescricao)
        {
            if (string.IsNullWhiteSpace(novaDescricao))
                throw new ArgumentException("Descrição inválida!");

            Descricao = novaDescricao;
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