using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;
using Desafio.Dominio.Generos;

namespace Desafio.Aplicacao.Generos.AlterarGenero
{
    internal sealed class AlterarGeneroCommandHandler : ICommandHandler<AlterarGeneroCommand>
    {
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public AlterarGeneroCommandHandler(
            IGeneroRepositorio generoRepositorio,
            IUnitOfWork unitOfWork)
        {
            _generoRepositorio = generoRepositorio;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AlterarGeneroCommand request, CancellationToken cancellationToken)
        {
            var genero = await _generoRepositorio.ObterPorIdAsync(request.id, cancellationToken);

            if (genero is null)
            {
                return Result.Failure(new Error("Genero.NaoEncontrado", "O gênero solicitado não foi encontrado."));
            }

            genero.AlterarNome(request.nome);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
