using Dominio.Comum;
using System.Collections.Generic;

namespace Dominio.Jogadores
{
    public class DadosDaCarreira : Entidade<DadosDaCarreira>
    {
        public Clubes ClubeAtual { get; set; }
        public List<Titulo> Titulos { get; set; }
        public string Biografia { get; set; }

        public DadosDaCarreira(Clubes clubeAtual, List<Titulo> titulos, string biografia)
        {
            ClubeAtual = clubeAtual;
            Titulos = titulos;
            Biografia = biografia;
        }
    }
}