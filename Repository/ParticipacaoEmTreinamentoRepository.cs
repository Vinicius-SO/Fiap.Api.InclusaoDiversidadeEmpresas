using InclusaoDiversidadeEmpresas.Data;
using InclusaoDiversidadeEmpresas.Models;

namespace Fiap.Api.InclusaoDiversidadeEmpresas.Repository
{
    public class ParticipacaoEmTreinamentoRepository : IParticipacaoEmTreinamentoRepository
    {
        private readonly DatabaseContext _context;
        public ParticipacaoEmTreinamentoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(ParticipacaoEmTreinamentoModel participacaoEmTreinamento)
        {
            _context.ParticipacoesEmTreinamento.Add(participacaoEmTreinamento);
        }

        public void Delete(ParticipacaoEmTreinamentoModel participacaoEmTreinamento)
        {
            _context.ParticipacoesEmTreinamento.Remove(participacaoEmTreinamento);
        }

        public IEnumerable<ParticipacaoEmTreinamentoModel> GetAll()
        {
            return _context.ParticipacoesEmTreinamento.ToList();
        }

        public ParticipacaoEmTreinamentoModel GetById(int id)
        {
            return _context.ParticipacoesEmTreinamento.Find(id);
        }

        public void Update(ParticipacaoEmTreinamentoModel participacaoEmTreinamento)
        {
            _context.ParticipacoesEmTreinamento.Update(participacaoEmTreinamento);
        }
    }
}
