using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;
using Desafio.Dominio.Autores;
using Desafio.Dominio.Generos;
using Desafio.Dominio.Livros;

namespace Desafio.Aplicacao.Livros.AdicionarLivro
{
    internal sealed class AdicionarLivroCommandHandler : ICommandHandler<AdicionarLivroCommand, Guid>
    {
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IAutorRepositorio _autorRepositorio;
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarLivroCommandHandler(
            ILivroRepositorio livroRepositorio,
            IAutorRepositorio autorRepositorio,
            IGeneroRepositorio generoRepositorio,
            IUnitOfWork unitOfWork)
        {
            _livroRepositorio = livroRepositorio;
            _autorRepositorio = autorRepositorio;
            _generoRepositorio = generoRepositorio;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(AdicionarLivroCommand request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepositorio.ObterPorIdAsync(request.AutorId, cancellationToken);
            if (autor is null)
            {
                return Result.Failure<Guid>(new Error("Autor.NaoEncontrado", "O autor informado não foi encontrado."));
            }

            var genero = await _generoRepositorio.ObterPorIdAsync(request.GeneroId, cancellationToken);
            if (genero is null)
            {
                return Result.Failure<Guid>(new Error("Genero.NaoEncontrado", "O gênero informado não foi encontrado."));
            }

            var livro = Livro.Criar(request.Nome, request.GeneroId, request.AutorId);
            _livroRepositorio.Adicionar(livro);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return livro.Id;
        }
    }
}
