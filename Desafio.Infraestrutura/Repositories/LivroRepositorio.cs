using Desafio.Dominio.Livros;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infraestrutura.Repositories
{
    internal class LivroRepositorio : Repository<Livro>, ILivroRepositorio
    {
        public LivroRepositorio(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<bool> ExisteParaAutorAsync(Guid autorId, CancellationToken cancellationToken)
        {
            return await DbContext.Set<Livro>()
                .AnyAsync(l => l.AutorId == autorId, cancellationToken);
        }

        public async Task<bool> ExisteParaGeneroAsync(Guid generoId, CancellationToken cancellationToken)
        {
            return await DbContext.Set<Livro>()
                .AnyAsync(l => l.GeneroId == generoId, cancellationToken);
        }
    }
}
