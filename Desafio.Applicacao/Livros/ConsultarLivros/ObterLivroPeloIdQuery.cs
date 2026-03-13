using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Livros.ConsultarLivros
{
    public sealed record ObterLivroPeloIdQuery(Guid id) : IQuery<LivroResponse>;
}
