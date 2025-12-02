using InclusaoDiversidadeEmpresas.Data;
using InclusaoDiversidadeEmpresas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using InclusaoDiversidadeEmpresas.ViewModels;
using System.Linq;

namespace InclusaoDiversidadeEmpresas.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly DatabaseContext _context;

        // Injeção de Dependência do DatabaseContext
        public ColaboradorService(DatabaseContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<Colaborador> AddColaborador(Colaborador colaborador)
        {
            _context.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync();
            return colaborador;
        }

        // READ (Listar Todos)
        public async Task<PagedResultViewModel<ColaboradorListaViewModel>> GetAllColaboradores(int page, int pageSize)
        {
            // 1. Descobre quantos itens existem no total (para calcular as páginas)
            var totalItems = await _context.Colaboradores.CountAsync();

            // 2. Busca apenas a página solicitada
            var items = await _context.Colaboradores
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new ColaboradorListaViewModel
                {
                    Id = c.Id,
                    Nome = c.NomeColaborador,
                    Departamento = c.Departamento,
                    Email = c.Email
                })
                .ToListAsync();

            // 3. Monta o pacote de resposta
            return new PagedResultViewModel<ColaboradorListaViewModel>
            {
                Items = items,
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize
            };
        }

        // READ (Por ID)
        public async Task<Colaborador?> GetColaboradorById(long id)
        {
            return await _context.Colaboradores.FindAsync(id);
        }

        // UPDATE (Lógica simplificada)
        public async Task<Colaborador?> UpdateColaborador(Colaborador colaborador)
        {
            _context.Entry(colaborador).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return colaborador;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Se a entidade não existir (concorrência), retorna null
                if (!await _context.Colaboradores.AnyAsync(e => e.Id == colaborador.Id))
                {
                    return null;
                }
                throw;
            }
        }

        // DELETE
        public async Task<bool> DeleteColaborador(long id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador == null)
            {
                return false;
            }

            _context.Colaboradores.Remove(colaborador);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
