using InclusaoDiversidadeEmpresas.Data;
using InclusaoDiversidadeEmpresas.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Repository
{
    public class TreinamentoRepository : ITreinamentoRepository
    {
        private readonly DatabaseContext _context;
        public TreinamentoRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(TreinamentoModel treinamento)
        {
            _context.Treinamentos.Add(treinamento);
            _context.SaveChanges();
        }

        public void Delete(TreinamentoModel treinamento)
        {
            _context.Treinamentos.Remove(treinamento);
            _context.SaveChanges();
        }

        public IEnumerable<TreinamentoModel> GetAll()
        {
            return _context.Treinamentos.Include(c => c.Participacao).ToList();
        }

        public TreinamentoModel GetById(int id)
        {
            return _context.Treinamentos.Find(id);
        }

        public void Update(TreinamentoModel treinamento)
        {
            _context.Treinamentos.Update(treinamento);
            _context.SaveChanges();
        }
    }
}
