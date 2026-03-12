using Desafio.Dominio.Generos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infraestrutura.Repositories
{
    internal class GeneroRepositorio : Repository<Genero>, IGeneroRepositorio
    {
        public GeneroRepositorio(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
