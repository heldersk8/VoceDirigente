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

    public class Titulo : ObjetoDeValor<Titulo>
    {
        protected override bool TodosOsAtributosSaoIguais(Titulo outroObjetoDeValor)
        {
            throw new System.NotImplementedException();
        }

        protected override int ObterHashCode()
        {
            throw new System.NotImplementedException();
        }
    }

    public enum Clubes
    {
        Cruzeiro = 1,
        Corinthians = 2,
        Flamengo = 3,
        Grêmio = 4,
        Santos = 5,
        Atlético = 6

    }
}