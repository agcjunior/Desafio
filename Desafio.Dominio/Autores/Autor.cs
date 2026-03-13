using Desafio.Comum;

namespace Desafio.Dominio.Autores
{
    public class Autor : Entity
    {       
        private Autor() 
        {
        }

        private Autor(Guid id, string nome) : base(id)
        {            
            Nome = nome;
        }
        
        public string Nome { get; private set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public static Autor Criar(string nome)
        {
            var autor = new Autor(Guid.NewGuid(), nome);
            return autor;
        }
    }
}
