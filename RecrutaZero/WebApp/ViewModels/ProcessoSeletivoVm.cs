using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecrutaZero.WebApp.ViewModels
{
    public class ProcessoSeletivoVm
    {
        [Required(ErrorMessage = "Ocupação deve ser informada")]
        public int OcupacaoId { get; set; }
        public IEnumerable<OcupacaoVm> Ocupacoes { get; set; }

        [Required(ErrorMessage = "Time deve ser informado")]
        public string ParaOTime { get; set; }

        [Required(ErrorMessage = "Descrição deve ser informada")]
        public string DescricaoDaVaga { get; set; }
    }
}