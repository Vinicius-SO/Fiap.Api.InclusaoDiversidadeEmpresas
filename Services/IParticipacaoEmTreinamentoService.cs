using InclusaoDiversidadeEmpresas.Models;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Services
{
    public interface IParticipacaoEmTreinamentoService
    {
        IEnumerable<ParticipacaoEmTreinamentoModel> ListarClientes();
        ParticipacaoEmTreinamentoModel ObterClientePorId(int id);
        void CriarCliente(ParticipacaoEmTreinamentoModel participacaoEmTreinamentoModel);
        void AtualizarCliente(ParticipacaoEmTreinamentoModel participacaoEmTreinamentoModel);
        void DeletarCliente(int id);
    }
}
