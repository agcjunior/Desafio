using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;
using Desafio.Dominio.Autores;

namespace Desafio.Aplicacao.Autores.AlterarAutor
{
    internal sealed class AlterarAutorCommandHandler : ICommandHandler<AlterarAutorCommand>
    {
        private readonly IAutorRepositorio _autorRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public AlterarAutorCommandHandler(
            IAutorRepositorio autorRepositorio,
            IUnitOfWork unitOfWork)
        {
            _autorRepositorio = autorRepositorio;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AlterarAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepositorio.ObterPorIdAsync(request.id, cancellationToken);

            if (autor is null)
            {
                return Result.Failure(new Error("Autor.NaoEncontrado", "O autor solicitado não foi encontrado."));
            }

            autor.AlterarNome(request.nome);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
