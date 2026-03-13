using Dapper;
using Desafio.Aplicacao.Interfaces;
using Desafio.Dominio.Autores;
using Desafio.Dominio.Generos;
using Desafio.Dominio.Livros;

namespace Desafio.Api.Extensions
{
    public static class SeedDataExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
            using var connection = sqlConnectionFactory.CreateConnection();

            var platao = Autor.Criar("Platão");
            var filosofia = Genero.Criar("Filosofia");
            var livro = Livro.Criar("A Republica", filosofia.Id, platao.Id);

            const string sqlCheckAutor = "SELECT COUNT(1) FROM Autores WHERE Nome = @Nome";
            if (connection.ExecuteScalar<int>(sqlCheckAutor, new { platao.Nome }) == 0)
            {
                const string sqlAutor = """"
                    INSERT INTO Autores (Id, Nome) VALUES (@Id, @Nome);
                    """";
                connection.Execute(sqlAutor, platao);
            }

            const string sqlCheckGenero = "SELECT COUNT(1) FROM Generos WHERE Nome = @Nome";
            if (connection.ExecuteScalar<int>(sqlCheckGenero, new { filosofia.Nome }) == 0)
            {
                const string sqlGenero = """"
                    INSERT INTO Generos (Id, Nome) VALUES (@Id, @Nome);
                    """";
                connection.Execute(sqlGenero, filosofia);
            }

            const string sqlCheckLivro = "SELECT COUNT(1) FROM Livros WHERE Nome = @Nome";
            if (connection.ExecuteScalar<int>(sqlCheckLivro, new { livro.Nome }) == 0)
            {
                // Note: Re-fetching IDs if the entities above already existed would be more robust,
                // but since these are static seed values, we check if the book itself exists.
                const string sqlLivro = """"
                    INSERT INTO Livros (Id, Nome, GeneroId, AutorId) VALUES (@Id, @Nome, @GeneroId, @AutorId);
                    """";
                
                // If the book doesn't exist but Author/Genre might, we need to ensure we use existing IDs
                // However, for this simple seed, we'll fetch them if they exist or use the ones we created.
                var existingAutorId = connection.ExecuteScalar<Guid?>("SELECT Id FROM Autores WHERE Nome = @Nome", new { platao.Nome });
                var existingGeneroId = connection.ExecuteScalar<Guid?>("SELECT Id FROM Generos WHERE Nome = @Nome", new { filosofia.Nome });

                connection.Execute(sqlLivro, new 
                { 
                    livro.Id, 
                    livro.Nome, 
                    GeneroId = existingGeneroId ?? filosofia.Id, 
                    AutorId = existingAutorId ?? platao.Id 
                });
            }

        }
    }
}
