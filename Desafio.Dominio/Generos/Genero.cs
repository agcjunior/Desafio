using Desafio.Comum;

namespace Desafio.Dominio.Generos
{
    public class Genero : Entity
    {
        private Genero()
        {
        }
        private Genero(Guid id, string nome) : base(id)
        {
            Id = id;
            Nome = nome;
        }
        public string Nome { get; private set; }

        public static Genero Criar(string  nome)
        {
            var genero = new Genero(Guid.NewGuid(), nome);
            return genero;
        }
    }
}
