namespace Desafio.Aplicacao.Livros.ConsultarLivros
{
    public sealed class LivroResponse
    {
        public Guid Id { get; init; }
        public string Nome { get; init; }
        public Guid GeneroId { get; init; }
        public string GeneroNome { get; init; }
        public Guid AutorId { get; init; }
        public string AutorNome { get; init; }
    }
}
