using Desafio.Aplicacao.Generos.AdicionarGenero;
using Desafio.Aplicacao.Generos.ConsultarGeneros;
using Desafio.Aplicacao.Generos.ExcluirGenero;
using Desafio.Aplicacao.Generos.AlterarGenero;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Desafio.Api.Controllers.Generos.dtos;

namespace Desafio.Api.Controllers.Generos
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ISender _sender;

        public GenerosController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> ListarGeneros(CancellationToken cancellationToken)
        {
            var query = new ListarGenerosQuery();
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterGeneroPeloId(Guid id, CancellationToken cancellationToken)
        {
            var query = new ObterGeneroPeloIdQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> IncluirGenero(
            IncluirGeneroRequest request,
            CancellationToken cancellationToken)
        {
            var command = new AdicionarGeneroCommand(request.Nome);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(ObterGeneroPeloId), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> AlterarGenero(
            Guid id,
            [FromBody] AlterarGeneroRequest request,
            CancellationToken cancellationToken)
        {
            var command = new AlterarGeneroCommand(id, request.Nome);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> ExcluirGenero(Guid id, CancellationToken cancellationToken)
        {
            var command = new ExcluirGeneroCommand(id);
            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}
