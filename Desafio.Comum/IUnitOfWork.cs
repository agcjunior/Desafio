using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Comum
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
