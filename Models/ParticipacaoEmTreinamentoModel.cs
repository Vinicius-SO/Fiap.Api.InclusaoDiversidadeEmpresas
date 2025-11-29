using System;
using System.ComponentModel.DataAnnotations.Schema; 

namespace InclusaoDiversidadeEmpresas.Models
{
    public class ParticipacaoEmTreinamentoModel
    {
        public long Id { get; set; }

      
        public long ColaboradorId { get; set; }
      
        public Colaborador? Colaborador { get; set; }

        public long TreinamentoId { get; set; }
     
        public TreinamentoModel? Treinamento { get; set; }

        public bool Completo { get; set; }

        public DateTime? DataDeConclusao { get; set; }
    }
}

