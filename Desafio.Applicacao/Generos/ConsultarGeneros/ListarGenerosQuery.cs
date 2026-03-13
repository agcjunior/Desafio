using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Generos.ConsultarGeneros
{
    public sealed record ListarGenerosQuery() : IQuery<IEnumerable<GeneroResponse>>;
}
