using InclusaoDiversidadeEmpresas.Models;
using InclusaoDiversidadeEmpresas.ViewModels;

namespace InclusaoDiversidadeEmpresas.Services
{
    // Interface que define os métodos que o Controller pode chamar
    public interface IColaboradorService
    {
        // CREATE
        Task<Colaborador> AddColaborador(Colaborador colaborador);

        // READ (Listar Todos)
        Task<PagedResultViewModel<ColaboradorListaViewModel>> GetAllColaboradores(int page, int pageSize);

        // READ (Por ID)
        Task<Colaborador?> GetColaboradorById(long id);

        // UPDATE
        Task<Colaborador?> UpdateColaborador(Colaborador colaborador);

        // DELETE
        Task<bool> DeleteColaborador(long id);
    }
}
