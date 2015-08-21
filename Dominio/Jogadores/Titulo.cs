using Dominio.Comum;

namespace Dominio.Jogadores
{
    public class Titulo : ObjetoDeValor<Titulo>
    {
        public string NomeDoCampeonato { get; set; }
        public int Ano { get; set; }
        public int QuantidadeDeGols { get; set; }

        protected override bool TodosOsAtributosSaoIguais(Titulo outroObjetoDeValor)
        {
            throw new System.NotImplementedException();
        }

        protected override int ObterHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}