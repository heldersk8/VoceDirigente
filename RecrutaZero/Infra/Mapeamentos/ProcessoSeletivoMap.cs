using RecrutaZero.Dominio;
using RecrutaZero.Infra._Base.Mapeamentos;

namespace RecrutaZero.Infra.Mapeamentos
{
    public class ProcessoSeletivoMap : MapBase<ProcessoSeletivo>
    {
        public ProcessoSeletivoMap()
        {
            References(x => x.Ocupacao);
            Map(x => x.ParaOTime);
            Map(x => x.DescricaoDaVaga);
            Map(x => x.Status);
            HasMany(x => x.Candidatos).Cascade.All();
        }
    }
}