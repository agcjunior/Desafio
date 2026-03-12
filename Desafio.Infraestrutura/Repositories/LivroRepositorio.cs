using Desafio.Dominio.Livros;

namespace Desafio.Infraestrutura.Repositories
{
    internal class LivroRepositorio : Repository<Livro>, ILivroRepositorio
    {
        public LivroRepositorio(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
