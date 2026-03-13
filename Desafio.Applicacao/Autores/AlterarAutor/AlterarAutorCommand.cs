using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Autores.AlterarAutor
{
    public sealed record AlterarAutorCommand(Guid id, string nome) : ICommand;
}
