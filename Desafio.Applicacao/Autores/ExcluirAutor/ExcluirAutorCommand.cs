using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Autores.ExcluirAutor
{
    public sealed record ExcluirAutorCommand(Guid id) : ICommand;
}
