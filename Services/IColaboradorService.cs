using InclusaoDiversidadeEmpresas.Models;
using InclusaoDiversidadeEmpresas.ViewModels;

namespace InclusaoDiversidadeEmpresas.Services
{
    // Interface que define os métodos que o Controller pode chamar
    public interface IColaboradorService
    {
        Task<Colaborador> AddColaborador(Colaborador colaborador);

        Task<PagedResultViewModel<ColaboradorListaViewModel>> GetAllColaboradores(int page, int pageSize);

        Task<IEnumerable<Colaborador>> GetAllColaboradoresSemPaginacao();
        Task<Colaborador?> GetColaboradorById(long id);

        Task<Colaborador?> UpdateColaborador(Colaborador colaborador);

        Task<bool> DeleteColaborador(long id);
    }
}
