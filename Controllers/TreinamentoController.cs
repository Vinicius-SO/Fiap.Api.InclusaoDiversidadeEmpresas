using Fiap.Api.InclusaoDiversidadeEmpresas.Services;
using InclusaoDiversidadeEmpresas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TreinamentoController : ControllerBase
    {
        private readonly ITreinamentoService _treinamentoService;

        public TreinamentoController(ITreinamentoService treinamentoService)
        {
            _treinamentoService = treinamentoService;
        }

        // GET: api/treinamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreinamentoModel>>> GetTreinamentos()
        {
            return Ok(await _treinamentoService.ListarTreinamentos());
        }

        // GET: api/treinamento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TreinamentoModel>> GetTreinamento(int id)
        {
            var treinamento = await _treinamentoService.ObterTreinamentoPorId(id);

            if (treinamento == null)
                return NotFound();

            return Ok(treinamento);
        }

        // POST: api/treinamento
        [HttpPost]
        public async Task<ActionResult<TreinamentoModel>> PostTreinamento(TreinamentoModel treinamento)
        {
            var criado = await _treinamentoService.CriarTreinamento(treinamento);

            return CreatedAtAction(nameof(GetTreinamento), new { id = criado.Id }, criado);
        }

        // PUT: api/treinamento/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<TreinamentoModel>> PutTreinamento(int id, TreinamentoModel treinamento)
        {
            if (id != treinamento.Id)
                return BadRequest("O ID informado não corresponde ao objeto enviado.");

            var atualizado = await _treinamentoService.AtualizarTreinamento(treinamento);

            if (atualizado == null)
                return NotFound();

            return Ok(atualizado);
        }

        // DELETE: api/treinamento/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreinamento(long id)
        {
            var removido = await _treinamentoService.DeletarTreinamento(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
