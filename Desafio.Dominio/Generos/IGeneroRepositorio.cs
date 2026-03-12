namespace Desafio.Dominio.Generos
{
    public interface IGeneroRepositorio
    {
        Task<Genero?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Adicionar(Genero genero);
    }
}
