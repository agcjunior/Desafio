using Desafio.Comum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Aplicacao.Interfaces
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {
    }

    public interface IBaseCommand
    {
    }
}
