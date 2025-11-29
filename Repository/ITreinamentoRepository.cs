using InclusaoDiversidadeEmpresas.Models;
namespace Fiap.Api.InclusaoDiversidadeEmpresas.Repository
{
    public interface ITreinamentoRepository
    {
        IEnumerable<TreinamentoModel> GetAll();
        TreinamentoModel GetById(int id);
        void Add(TreinamentoModel cliente);
        void Update(TreinamentoModel cliente);
        void Delete(TreinamentoModel cliente);
    }
}
