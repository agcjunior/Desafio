using Desafio.Aplicacao.Autores.AdicionarAutor;
using Desafio.Aplicacao.Autores.ConsultarAutores;
using Desafio.Aplicacao.Autores.ExcluirAutor;
using Desafio.Aplicacao.Autores.AlterarAutor;
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

        [HttpGet]
        public async Task<IActionResult> ListarAutores(CancellationToken cancellationToken)
        {
            var query = new ListarAutoresQuery();
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
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

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> AlterarAutor(
            Guid id,
            [FromBody] AlterarAutorRequest request,
            CancellationToken cancellationToken)
        {
            var command = new AlterarAutorCommand(id, request.Nome);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> ExcluirAutor(Guid id, CancellationToken cancellationToken)
        {
            var command = new ExcluirAutorCommand(id);
            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}
