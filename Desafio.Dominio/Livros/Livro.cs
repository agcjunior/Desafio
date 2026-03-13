using Desafio.Comum;
using Desafio.Dominio.Autores;
using Desafio.Dominio.Generos;

namespace Desafio.Dominio.Livros
{
    
    public class Livro : Entity
    {
        private Livro()
        {
        }   

        private Livro(Guid id, string nome, Guid generoId, Guid authorId) : base(id)
        {              
            Nome = nome;
            GeneroId = generoId;
            AutorId = authorId;
        }
        
        public string Nome { get; private set; }
        public Guid GeneroId { get; private set; }
        public Guid AutorId { get; private set; }
        public Genero Genero { get; private set; }
        public Autor Autor { get; private set; }

        public static Livro Criar(string nome,  Guid generoId, Guid authorId)
        {
            var livro = new Livro(Guid.NewGuid(), nome, generoId, authorId);
            return livro;
        }
    }
}
