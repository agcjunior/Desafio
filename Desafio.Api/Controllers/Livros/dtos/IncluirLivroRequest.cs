namespace Desafio.Api.Controllers.Livros.dtos
{
    public sealed record IncluirLivroRequest(string Nome, Guid GeneroId, Guid AutorId);
}
