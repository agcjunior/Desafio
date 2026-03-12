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

            const string sqlAutor = """"
                INSERT INTO public.autores (Id, Nome) VALUES (@Id, @Nome);
                """";
            connection.Execute(sqlAutor, platao);

            const string sqlGenero = """"
                INSERT INTO public.generos (Id, Nome) VALUES (@Id, @Nome);
                """";
            connection.Execute(sqlGenero, filosofia);

            const string sqlLivro = """"
                INSERT INTO public.livros (Id, Nome, GeneroId, AutorId) VALUES (@Id, @Nome, @GeneroId, @AutorId);
                """";
            connection.Execute(sqlLivro, livro);

        }
    }
}
