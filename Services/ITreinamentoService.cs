using InclusaoDiversidadeEmpresas.Models;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Services
{
    public interface ITreinamentoService
    {
        public Task<IEnumerable<TreinamentoModel>> ListarTreinamentosPaginado(int pagina, int tamanho);
        Task<TreinamentoModel?> ObterTreinamentoPorId(long id);
        Task<TreinamentoModel> CriarTreinamento(TreinamentoModel treinamento);
        Task<TreinamentoModel?> AtualizarTreinamento(TreinamentoModel treinamento);
        Task<bool> DeletarTreinamento(long id);
    }
}
