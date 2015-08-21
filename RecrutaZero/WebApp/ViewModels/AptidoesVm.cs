using System.Collections.Generic;
using RecrutaZero.Dominio;

namespace RecrutaZero.WebApp.ViewModels
{
    public class AptidoesVm
    {
        public string Nome { get; set; }
        public IEnumerable<Passo> Passos { get; set; }
    }
}