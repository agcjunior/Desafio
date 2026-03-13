using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Generos.ExcluirGenero
{
    public sealed record ExcluirGeneroCommand(Guid id) : ICommand;
}
