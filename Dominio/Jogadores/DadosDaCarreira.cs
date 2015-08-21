using Dominio.Comum;
using System.Collections.Generic;

namespace Dominio.Jogadores
{
    public class DadosDaCarreira : Entidade<DadosDaCarreira>
    {
        public Clubes Clube { get; set; }
        public IList<Titulo> Titulos { get; set; }
        public string Biografia { get; set; }

    }
}