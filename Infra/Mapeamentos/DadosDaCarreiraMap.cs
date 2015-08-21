using Dominio.Jogadores;
using Infra._Base.Mapeamentos;

namespace Infra.Mapeamentos
{
    public class DadosDaCarreiraMap : MapBase<DadosDaCarreira>
    {

        public DadosDaCarreiraMap()
        {
            References(x => x.Jogador);
            Map(x => x.Biografia).Length(4001);
            Map(x => x.ClubeAtual);
            HasMany(x => x.Titulos).Cascade.AllDeleteOrphan();
        }
    }
}
