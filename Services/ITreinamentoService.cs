using InclusaoDiversidadeEmpresas.Models;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Services
{
    public interface ITreinamentoService
    {
        IEnumerable<TreinamentoModel> ListarClientes();
        TreinamentoModel ObterClientePorId(int id);
        void CriarCliente(TreinamentoModel treinamento);
        void AtualizarCliente(TreinamentoModel treinamento);
        void DeletarCliente(int id);
    }
}
