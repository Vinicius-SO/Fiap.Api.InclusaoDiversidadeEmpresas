using InclusaoDiversidadeEmpresas.Models;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Repository
{
    public interface IParticipacaoEmTreinamentoRepository
    {
        IEnumerable<ParticipacaoEmTreinamentoModel> GetAll();
        ParticipacaoEmTreinamentoModel GetById(int id);
        void Add(ParticipacaoEmTreinamentoModel participacaoEmTreinamento);
        void Update(ParticipacaoEmTreinamentoModel participacaoEmTreinamento);
        void Delete(ParticipacaoEmTreinamentoModel participacaoEmTreinamento);
    }
}
