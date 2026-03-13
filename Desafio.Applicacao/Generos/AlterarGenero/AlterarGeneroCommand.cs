using Desafio.Aplicacao.Interfaces;

namespace Desafio.Aplicacao.Generos.AlterarGenero
{
    public sealed record AlterarGeneroCommand(Guid id, string nome) : ICommand;
}
