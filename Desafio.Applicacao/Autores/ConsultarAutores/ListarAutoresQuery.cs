using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Autores.ConsultarAutores
{
    public sealed record ListarAutoresQuery : IQuery<IEnumerable<AutorResponse>>
    {
    }
}
