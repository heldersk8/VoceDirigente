using Dominio.Jogadores;
using Infra._Base.Mapeamentos;

namespace Infra.Mapeamentos
{
    public class TituloMap : MapBase<Titulo>
    {
        public TituloMap()
        {
            Map(x => x.Ano);
            Map(x => x.NomeDoCampeonato);
            Map(x => x.QuantidadeDeGols);
        }
    }
}
