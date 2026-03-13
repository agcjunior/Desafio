using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Livros.ConsultarLivros
{
    public sealed record ObterLivrosPeloGeneroIdQuery(Guid GeneroId) : IQuery<IEnumerable<LivroResponse>>;
}
