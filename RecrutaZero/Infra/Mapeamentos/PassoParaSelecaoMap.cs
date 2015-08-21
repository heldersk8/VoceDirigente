using RecrutaZero.Dominio;
using RecrutaZero.Infra._Base.Mapeamentos;

namespace RecrutaZero.Infra.Mapeamentos
{
    public class PassoParaSelecaoMap : MapBase<PassoParaSelecao>
    {
        public PassoParaSelecaoMap()
        {
            References(x => x.Passo).Not.Nullable().Fetch.Join();
            Map(x => x.Observacao);
            Map(x => x.Data);
            Map(x => x.Status);
        }
    }
}