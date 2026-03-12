using System.Data;

namespace Desafio.Aplicacao.Interfaces
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
