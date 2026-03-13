using Desafio.Comum;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infraestrutura.Repositories
{
    internal abstract class Repository<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await DbContext
                .Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Adicionar(T entity)
        {
            DbContext.Add(entity);
        }

        public void Remover(T entity)
        {
            DbContext.Remove(entity);
        }

    }
}
