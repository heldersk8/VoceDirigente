using Dominio.Comum;
using System.Collections.Generic;

namespace Dominio.Jogadores
{
    public class DadosDaCarreira : Entidade<DadosDaCarreira>
    {
        public virtual Clubes ClubeAtual { get; set; }
        public virtual IEnumerable<Titulo> Titulos { get; set; }
        public virtual string Biografia { get; set; }
        public virtual Jogador Jogador { get; set; }

        protected DadosDaCarreira() { }

        public DadosDaCarreira(Clubes clubeAtual, List<Titulo> titulos, string biografia)
        {
            ClubeAtual = clubeAtual;
            Titulos = titulos;
            Biografia = biografia;
        }
    }
}