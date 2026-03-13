using Desafio.Aplicacao.Livros.AdicionarLivro;
using Desafio.Aplicacao.Livros.ConsultarLivros;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Desafio.Api.Controllers.Livros.dtos;

namespace Desafio.Api.Controllers.Livros
{
    [Route("api/livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ISender _sender;

        public LivrosController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> ListarLivros(CancellationToken cancellationToken)
        {
            var query = new ListarLivrosQuery();
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterLivroPeloId(Guid id, CancellationToken cancellationToken)
        {
            var query = new ObterLivroPeloIdQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpGet("autor/{autorId:guid}")]
        public async Task<IActionResult> ObterLivrosPeloAutorId(Guid autorId, CancellationToken cancellationToken)
        {
            var query = new ObterLivrosPeloAutorIdQuery(autorId);
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("genero/{generoId:guid}")]
        public async Task<IActionResult> ObterLivrosPeloGeneroId(Guid generoId, CancellationToken cancellationToken)
        {
            var query = new ObterLivrosPeloGeneroIdQuery(generoId);
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> IncluirLivro(
            IncluirLivroRequest request,
            CancellationToken cancellationToken)
        {
            var command = new AdicionarLivroCommand(request.Nome, request.GeneroId, request.AutorId);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(ObterLivroPeloId), new { id = result.Value }, result.Value);
        }
    }
}
