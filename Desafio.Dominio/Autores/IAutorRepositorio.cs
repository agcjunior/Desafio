namespace Desafio.Dominio.Autores
{
    public interface IAutorRepositorio
    {
        Task<Autor?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Adicionar(Autor autor);
        void Remover(Autor autor);
    }
}
