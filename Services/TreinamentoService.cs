using InclusaoDiversidadeEmpresas.Data;
using InclusaoDiversidadeEmpresas.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Services
{
    public class TreinamentoService : ITreinamentoService
    {
        private readonly DatabaseContext _databaseContext;

        public TreinamentoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<TreinamentoModel?> AtualizarTreinamento(long id, TreinamentoModel model)
        {
            var existente = await _databaseContext.Treinamentos.FindAsync(id);

            if (existente == null)
                return null;

            // Atualiza os campos permitidos
            existente.Titulo = model.Titulo;
            existente.Descricao = model.Descricao;
            existente.Data = model.Data;

            await _databaseContext.SaveChangesAsync();

            return existente;
        }

        public async Task<TreinamentoModel> CriarTreinamento(TreinamentoModel treinamento)
        {
            _databaseContext.Treinamentos.Add(treinamento);
            await _databaseContext.SaveChangesAsync();
            return treinamento;
        }

        public async Task<bool> DeletarTreinamento(long id)
        {
            var treinamento = await _databaseContext.Treinamentos.FindAsync(id);

            if (treinamento == null)
                return false;

            var participacoes = _databaseContext.ParticipacoesEmTreinamento
                .Where(p => p.TreinamentoId == id);

            _databaseContext.ParticipacoesEmTreinamento.RemoveRange(participacoes);
            _databaseContext.Treinamentos.Remove(treinamento);

            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TreinamentoModel>> ListarTreinamentosPaginado(int pagina, int tamanho)
        {
            return await _databaseContext.Treinamentos
                .OrderBy(t => t.Id)
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .ToListAsync();
        }

        public async Task<TreinamentoModel?> ObterTreinamentoPorId(long id)
        {
            return await _databaseContext.Treinamentos
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }

}
