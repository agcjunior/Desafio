using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Livros.ConsultarLivros
{
    public sealed record ObterLivrosPeloAutorIdQuery(Guid AutorId) : IQuery<IEnumerable<LivroResponse>>;
}
