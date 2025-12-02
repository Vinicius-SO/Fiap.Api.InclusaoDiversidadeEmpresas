using InclusaoDiversidadeEmpresas.Models;

public interface ITreinamentoService
{
    Task<IEnumerable<TreinamentoModel>> ListarTreinamentosPaginado(int pagina, int tamanho);
    Task<TreinamentoModel?> ObterTreinamentoPorId(long id);
    Task<TreinamentoModel> CriarTreinamento(TreinamentoModel treinamento);
    Task<TreinamentoModel?> AtualizarTreinamento(long id, TreinamentoModel treinamento);
    Task<bool> DeletarTreinamento(long id);
}
