using AutoMapper;
using Fiap.Api.InclusaoDiversidadeEmpresas.Services;
using Fiap.Api.InclusaoDiversidadeEmpresas.ViewModel;
using InclusaoDiversidadeEmpresas.Models;
using InclusaoDiversidadeEmpresas.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TreinamentoController : ControllerBase
    {
        private readonly ITreinamentoService _treinamentoService;
        private readonly IMapper _mapper;

        public TreinamentoController(
            ITreinamentoService treinamentoService,
            IMapper mapper)
        {
            _treinamentoService = treinamentoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TreinamentoPaginacaoViewModel>> GetTreinamentos(
         [FromQuery] int pagina = 1,
         [FromQuery] int tamanho = 10)
        {
            if (pagina < 1 || tamanho < 1)
                return BadRequest("Página e tamanho devem ser maiores que zero.");

            var treinamentos = await _treinamentoService.ListarTreinamentosPaginado(pagina, tamanho);

            var vm = _mapper.Map<IEnumerable<TreinamentoViewModel>>(treinamentos);

            return Ok(new TreinamentoPaginacaoViewModel
            {
                Treinamentos = (IEnumerable<TreinamentoModel>)vm,
                PaginaAtual = pagina,
                TamanhoPagina = tamanho
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TreinamentoViewModel>> GetTreinamento(long id)
        {
            var treinamento = await _treinamentoService.ObterTreinamentoPorId(id);

            if (treinamento == null)
                return NotFound();

            return Ok(_mapper.Map<TreinamentoViewModel>(treinamento));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<TreinamentoViewModel>> PostTreinamento(TreinamentoViewModel vm)
        {
            var model = _mapper.Map<TreinamentoModel>(vm);

            var criado = await _treinamentoService.CriarTreinamento(model);

            var retorno = _mapper.Map<TreinamentoViewModel>(criado);

            return CreatedAtAction(nameof(GetTreinamento), new { id = criado.Id }, retorno);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutTreinamento(long id, TreinamentoViewModel vm)
        {
            if (id != vm.Id)
                return BadRequest("O ID informado não corresponde ao objeto enviado.");

            var model = _mapper.Map<TreinamentoModel>(vm);

            var atualizado = await _treinamentoService.AtualizarTreinamento(id, model);

            if (atualizado == null)
                return NotFound();

            return Ok(_mapper.Map<TreinamentoViewModel>(atualizado));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTreinamento(long id)
        {
            var removido = await _treinamentoService.DeletarTreinamento(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
