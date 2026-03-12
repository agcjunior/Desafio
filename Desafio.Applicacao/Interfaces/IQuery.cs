using Desafio.Comum;
using MediatR;

namespace Desafio.Aplicacao.Interfaces
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
