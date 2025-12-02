

using Fiap.Api.InclusaoDiversidadeEmpresas.Models;
using Fiap.Api.InclusaoDiversidadeEmpresas.Services;
using Fiap.Api.InclusaoDiversidadeEmpresas.ViewModels; 
using InclusaoDiversidadeEmpresas.Models;
using InclusaoDiversidadeEmpresas.Services;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Fiap.Api.InclusaoDiversidadeEmpresas.Services
{
   
    public class RelatorioService : IRelatorioService
    {
        private readonly IColaboradorService _colaboradorService;

        public RelatorioService(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        public async Task<RelatorioDeDiversidadeModel> GerarRelatorioAsync()
        {
            
            var allRecordsQuery = new QueryParameters
            {
                PageNumber = 1,
                PageSize = int.MaxValue 
            };

           
            var colaboradoresVM = await _colaboradorService.GetAllColaboradores(allRecordsQuery);

          
            var listaColaboradores = colaboradoresVM.Items.ToList();

         
            var totalColaborador = listaColaboradores.Count;

            var contagemDeMulheres = listaColaboradores
                .Count(c => c.GeneroColaborador.Equals("Feminino", StringComparison.OrdinalIgnoreCase));

            var contagemDePessoasNegras = listaColaboradores
                .Count(c => c.EtniaColaborador.Equals("Preta", StringComparison.OrdinalIgnoreCase) ||
                            c.EtniaColaborador.Equals("Parda", StringComparison.OrdinalIgnoreCase));

            var contagemDePessoasComDesabilidade = listaColaboradores
                .Count(c => c.TemDisabilidade);

            var contagemDePessoasLgbt = listaColaboradores
                .Count(c => !c.GeneroColaborador.Equals("Masculino", StringComparison.OrdinalIgnoreCase) &&
                            !c.GeneroColaborador.Equals("Feminino", StringComparison.OrdinalIgnoreCase));

          
            var relatorio = new RelatorioDeDiversidadeModel
            {
                Id = 1,
                DataGerada = DateTime.Now,
                TotalColaborador = totalColaborador,
                ContagemDeMulheres = contagemDeMulheres,
                ContagemDePessoasNegras = contagemDePessoasNegras,
                ContagemDePessoasLgbt = contagemDePessoasLgbt,
                ContagemDePessoasComDesabilidade = contagemDePessoasComDesabilidade,
            };

            return relatorio;
        }
    }
}