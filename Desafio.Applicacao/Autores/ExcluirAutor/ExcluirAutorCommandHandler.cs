using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;
using Desafio.Dominio.Autores;
using Desafio.Dominio.Livros;

namespace Desafio.Aplicacao.Autores.ExcluirAutor
{
    internal sealed class ExcluirAutorCommandHandler : ICommandHandler<ExcluirAutorCommand>
    {
        private readonly IAutorRepositorio _autorRepositorio;
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ExcluirAutorCommandHandler(
            IAutorRepositorio autorRepositorio,
            ILivroRepositorio livroRepositorio,
            IUnitOfWork unitOfWork)
        {
            _autorRepositorio = autorRepositorio;
            _livroRepositorio = livroRepositorio;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ExcluirAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepositorio.ObterPorIdAsync(request.id, cancellationToken);

            if (autor is null)
            {
                return Result.Failure(new Error("Autor.NaoEncontrado", "O autor solicitado não foi encontrado."));
            }

            var existeLivroParaAutor = await _livroRepositorio.ExisteParaAutorAsync(request.id, cancellationToken);

            if (existeLivroParaAutor)
            {
                return Result.Failure(new Error("Autor.PossuiLivros", "Não é possível excluir um autor que possui livros associados."));
            }

            _autorRepositorio.Remover(autor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
