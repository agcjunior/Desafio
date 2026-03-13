using Dapper;
using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;

namespace Desafio.Aplicacao.Livros.ConsultarLivros
{
    public class ListarLivrosQueryHandler : IQueryHandler<ListarLivrosQuery, IEnumerable<LivroResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ListarLivrosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IEnumerable<LivroResponse>>> Handle(ListarLivrosQuery request, CancellationToken cancellationToken)
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
                """";

            var livros = await connection.QueryAsync<LivroResponse>(sql);

            return Result.Success(livros);
        }
    }
}
