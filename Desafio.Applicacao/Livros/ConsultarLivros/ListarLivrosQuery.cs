using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Livros.ConsultarLivros
{
    public sealed record ListarLivrosQuery() : IQuery<IEnumerable<LivroResponse>>;
}
