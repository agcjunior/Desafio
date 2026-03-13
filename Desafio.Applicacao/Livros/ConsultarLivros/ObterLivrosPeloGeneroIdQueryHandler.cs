using Dapper;
using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;

namespace Desafio.Aplicacao.Livros.ConsultarLivros
{
    public sealed class ObterLivrosPeloGeneroIdQueryHandler : IQueryHandler<ObterLivrosPeloGeneroIdQuery, IEnumerable<LivroResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ObterLivrosPeloGeneroIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IEnumerable<LivroResponse>>> Handle(ObterLivrosPeloGeneroIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """"
                SELECT 
                    l.Id, 
                    l.Nome, 
                    l.GeneroId, 
                    g.Nome AS GeneroNome, 
                    l.AutorId, 
                    a.Nome AS AutorNome
                FROM Livros l
                INNER JOIN Generos g ON l.GeneroId = g.Id
                INNER JOIN Autores a ON l.AutorId = a.Id
                WHERE l.GeneroId = @GeneroId
                """";

            var livros = await connection.QueryAsync<LivroResponse>(sql, new { request.GeneroId });

            return Result.Success(livros);
        }
    }
}
