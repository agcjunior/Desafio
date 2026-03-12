using Desafio.Dominio.Autores;

namespace Desafio.Infraestrutura.Repositories
{
    internal class AutorRepositorio : Repository<Autor>, IAutorRepositorio
    {
        public AutorRepositorio(ApplicationDbContext dbContext)
            : base(dbContext)
        {            
        }
    }
}
