using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;
using Desafio.Dominio.Generos;

namespace Desafio.Aplicacao.Generos.AdicionarGenero
{
    internal sealed class AdicionarGeneroCommandHandler : ICommandHandler<AdicionarGeneroCommand, Guid>
    {
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarGeneroCommandHandler(
            IGeneroRepositorio generoRepositorio,
            IUnitOfWork unitOfWork)
        {
            _generoRepositorio = generoRepositorio;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(AdicionarGeneroCommand request, CancellationToken cancellationToken)
        {
            var genero = Genero.Criar(request.nome);
            _generoRepositorio.Adicionar(genero);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return genero.Id;
        }
    }
}
