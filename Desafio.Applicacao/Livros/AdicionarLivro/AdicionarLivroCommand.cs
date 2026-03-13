using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Livros.AdicionarLivro
{
    public record AdicionarLivroCommand(string Nome, Guid GeneroId, Guid AutorId) : ICommand<Guid>;
}
