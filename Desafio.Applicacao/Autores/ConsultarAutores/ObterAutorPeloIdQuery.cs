using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Autores.ConsultarAutores
{
    public sealed record ObterAutorPeloIdQuery(Guid id) : IQuery<AutorResponse>;
    
}
