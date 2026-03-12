using Dapper;
using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;

namespace Desafio.Aplicacao.Autores.ConsultarAutores
{
    
    public class ObterAutorPeloIdQueryHandler : IQueryHandler<ObterAutorPeloIdQuery, AutorResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ObterAutorPeloIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<AutorResponse>> Handle(ObterAutorPeloIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """"
                SELECT Id, Nome
                FROM Autores
                WHERE id = @id
                """";

            var autor = await connection.QueryFirstOrDefaultAsync<AutorResponse>(
                sql, new { request.id });

            return autor;

        }
    }
}
