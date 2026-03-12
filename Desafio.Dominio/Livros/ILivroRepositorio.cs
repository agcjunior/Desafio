namespace Desafio.Dominio.Livros
{
    public interface ILivroRepositorio
    {
        Task<Livro?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Adicionar(Livro livro);
    }
}
