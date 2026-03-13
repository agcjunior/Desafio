using Dapper;
using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;

namespace Desafio.Aplicacao.Generos.ConsultarGeneros
{
    public class ObterGeneroPeloIdQueryHandler : IQueryHandler<ObterGeneroPeloIdQuery, GeneroResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ObterGeneroPeloIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<GeneroResponse>> Handle(ObterGeneroPeloIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """"
                SELECT Id, Nome
                FROM Generos
                WHERE id = @id
                """";

            var genero = await connection.QueryFirstOrDefaultAsync<GeneroResponse>(
                sql, new { request.id });

            return genero;
        }
    }
}
