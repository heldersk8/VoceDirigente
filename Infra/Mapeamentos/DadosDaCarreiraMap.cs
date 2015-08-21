using Dominio.Jogadores;
using Infra._Base.Mapeamentos;

namespace Infra.Mapeamentos
{
    public class DadosDaCarreiraMap : MapBase<DadosDaCarreira>
    {

        public DadosDaCarreiraMap()
        {
            Map(x => x.Biografia);
            Map(x => x.ClubeAtual);
            HasMany(x => x.Titulos).Cascade.AllDeleteOrphan();
        }
    }
}
