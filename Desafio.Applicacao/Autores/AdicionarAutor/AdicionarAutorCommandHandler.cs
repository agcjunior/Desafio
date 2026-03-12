using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;
using Desafio.Dominio.Autores;

namespace Desafio.Aplicacao.Autores.AdicionarAutor
{
    internal sealed class AdicionarAutorCommandHandler : ICommandHandler<AdicionarAutorCommand, Guid>
    {
        private readonly IAutorRepositorio _autorRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarAutorCommandHandler(
            IAutorRepositorio autorRepositorio,
            IUnitOfWork unitOfWork)
        {
            _autorRepositorio = autorRepositorio;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(AdicionarAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = Autor.Criar(request.nome);
            _autorRepositorio.Adicionar(autor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return autor.Id;
        }
    }
}
