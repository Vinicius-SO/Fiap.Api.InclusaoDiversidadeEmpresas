using InclusaoDiversidadeEmpresas.Models;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Services
{
    public interface ITreinamentoService
    {
        Task<IEnumerable<TreinamentoModel>> ListarTreinamentos();
        Task<TreinamentoModel?> ObterTreinamentoPorId(int id);
        Task<TreinamentoModel> CriarTreinamento(TreinamentoModel treinamento);
        Task<TreinamentoModel?> AtualizarTreinamento(TreinamentoModel treinamento);
        Task<bool> DeletarTreinamento(long id);
    }
}
