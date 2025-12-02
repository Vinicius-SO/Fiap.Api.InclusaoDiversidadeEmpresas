using System;
using System.ComponentModel.DataAnnotations;

namespace InclusaoDiversidadeEmpresas.ViewModels
{
    public class TreinamentoViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Data de Realização")]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }
    }

    // Para a tela onde você marca quem fez o treinamento
    public class RegistrarPresencaViewModel
    {
        public long TreinamentoId { get; set; }
        public string NomeTreinamento { get; set; } = string.Empty;

        // Lista de colaboradores para checkbox na view
        public List<ColaboradorCheckViewModel> Colaboradores { get; set; } = new();
    }

    public class ColaboradorCheckViewModel
    {
        public long ColaboradorId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Concluiu { get; set; }
    }
}