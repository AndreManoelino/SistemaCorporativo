using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SistemaCorporativo.Dominio.Entidades
{
    public class Funcionario
    {
        public Guid Id{get; private set;}
        public string Nome{get; private set;}
    }
}