using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Generos.ConsultarGeneros
{
    public sealed record ObterGeneroPeloIdQuery(Guid id) : IQuery<GeneroResponse>;
}
