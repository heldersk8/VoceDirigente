using System.Collections.Generic;
using RecrutaZero.Dominio;

namespace RecrutaZero.WebApp.ViewModels
{
    public class CandidatosParaSelecaoPorProcessoVm
    {
        public int ProcessoSeletivoId { get; set; }
        public StatusDoProcessoSeletivo ProcessoStatus { get; set; }
        public string Nome { get; set; }
        public IEnumerable<CandidatoParaSelecao> CandidatosParaSelecao { get; set; }
        public string DescricaoDaVaga { get; set; }
    }
}