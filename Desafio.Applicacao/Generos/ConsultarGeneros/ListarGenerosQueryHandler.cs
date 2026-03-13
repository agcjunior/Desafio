using Dapper;
using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;

namespace Desafio.Aplicacao.Generos.ConsultarGeneros
{
    public class ListarGenerosQueryHandler : IQueryHandler<ListarGenerosQuery, IEnumerable<GeneroResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ListarGenerosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IEnumerable<GeneroResponse>>> Handle(ListarGenerosQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """"
                SELECT Id, Nome
                FROM Generos
                """";

            var generos = await connection.QueryAsync<GeneroResponse>(sql);

            return Result.Success(generos);
        }
    }
}
