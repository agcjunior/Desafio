using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;
using Desafio.Dominio.Generos;
using Desafio.Dominio.Livros;

namespace Desafio.Aplicacao.Generos.ExcluirGenero
{
    internal sealed class ExcluirGeneroCommandHandler : ICommandHandler<ExcluirGeneroCommand>
    {
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ExcluirGeneroCommandHandler(
            IGeneroRepositorio generoRepositorio,
            ILivroRepositorio livroRepositorio,
            IUnitOfWork unitOfWork)
        {
            _generoRepositorio = generoRepositorio;
            _livroRepositorio = livroRepositorio;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ExcluirGeneroCommand request, CancellationToken cancellationToken)
        {
            var genero = await _generoRepositorio.ObterPorIdAsync(request.id, cancellationToken);

            if (genero is null)
            {
                return Result.Failure(new Error("Genero.NaoEncontrado", "O gênero solicitado não foi encontrado."));
            }

            var existeLivroParaGenero = await _livroRepositorio.ExisteParaGeneroAsync(request.id, cancellationToken);

            if (existeLivroParaGenero)
            {
                return Result.Failure(new Error("Genero.PossuiLivros", "Não é possível excluir um gênero que possui livros associados."));
            }

            _generoRepositorio.Remover(genero);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
