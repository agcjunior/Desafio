using Desafio.Aplicacao.Autores.AdicionarAutor;
using Desafio.Aplicacao.Autores.ConsultarAutores;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers.Autores
{
    [Route("api/autores")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ISender _sender;

        public AutoresController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterAutorPeloId(Guid id, CancellationToken cancellationToken)
        {
            var query = new ObterAutorPeloIdQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> IncluirAutor(
            IncluirAutorRequest request,
            CancellationToken cancellationToken)
        {
            var command = new AdicionarAutorCommand(request.Nome);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(ObterAutorPeloId), new { id = result.Value }, result.Value);
        }
    }
}
