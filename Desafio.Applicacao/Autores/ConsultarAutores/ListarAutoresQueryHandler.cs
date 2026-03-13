using Dapper;
using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;

namespace Desafio.Aplicacao.Autores.ConsultarAutores
{
    public class ListarAutoresQueryHandler : IQueryHandler<ListarAutoresQuery, IEnumerable<AutorResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ListarAutoresQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IEnumerable<AutorResponse>>> Handle(ListarAutoresQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """"
                SELECT Id, Nome
                FROM Autores
                """";

            var autores = await connection.QueryAsync<AutorResponse>(sql);

            return Result.Success(autores);
        }
    }
}
