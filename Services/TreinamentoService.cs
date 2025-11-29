using Fiap.Api.InclusaoDiversidadeEmpresas.Repository;
using InclusaoDiversidadeEmpresas.Models;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Services
{
    public class TreinamentoService : ITreinamentoService
    {
        private readonly ITreinamentoRepository _treinamentoRepository;
        public TreinamentoService(ITreinamentoRepository treinamentoRepository)
        {
            _treinamentoRepository = treinamentoRepository;
        }
        public void AtualizarCliente(TreinamentoModel treinamento)
        {
            _treinamentoRepository.Update(treinamento);
        }

        public void CriarCliente(TreinamentoModel treinamento)
        {
            _treinamentoRepository.Add(treinamento);
        }

        public void DeletarCliente(int id)
        {
            _treinamentoRepository.Delete(_treinamentoRepository.GetById(id));
        }

        public IEnumerable<TreinamentoModel> ListarClientes()
        {
            return _treinamentoRepository.GetAll();
        }

        public TreinamentoModel ObterClientePorId(int id)
        {
            return _treinamentoRepository.GetById(id);
        }
    }
}
