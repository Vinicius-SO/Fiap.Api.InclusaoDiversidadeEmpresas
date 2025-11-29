using Fiap.Api.InclusaoDiversidadeEmpresas.Repository;
using InclusaoDiversidadeEmpresas.Models;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Services
{
    public class ParticipacaoEmTreinamentoService : IParticipacaoEmTreinamentoService
    {
        private readonly IParticipacaoEmTreinamentoRepository _participacaoEmTreinamentoRepository;
        public ParticipacaoEmTreinamentoService(IParticipacaoEmTreinamentoRepository participacaoEmTreinamentoRepository)
        {
            _participacaoEmTreinamentoRepository = participacaoEmTreinamentoRepository;
        }
        public void AtualizarCliente(ParticipacaoEmTreinamentoModel participacaoEmTreinamentoModel)
        {
            _participacaoEmTreinamentoRepository.Update(participacaoEmTreinamentoModel);
        }

        public void CriarCliente(ParticipacaoEmTreinamentoModel participacaoEmTreinamentoModel)
        {
            _participacaoEmTreinamentoRepository.Add(participacaoEmTreinamentoModel);
        }

        public void DeletarCliente(int id)
        {
            _participacaoEmTreinamentoRepository.Delete(_participacaoEmTreinamentoRepository.GetById(id));
        }

        public IEnumerable<ParticipacaoEmTreinamentoModel> ListarClientes()
        {
            return _participacaoEmTreinamentoRepository.GetAll();
        }

        public ParticipacaoEmTreinamentoModel ObterClientePorId(int id)
        {
            return _participacaoEmTreinamentoRepository.GetById(id);
        }
    }
}
