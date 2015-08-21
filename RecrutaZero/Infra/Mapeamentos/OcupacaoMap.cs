using RecrutaZero.Dominio;
using RecrutaZero.Infra._Base.Mapeamentos;

namespace RecrutaZero.Infra.Mapeamentos
{
    public class OcupacaoMap : MapBase<Ocupacao>
    {
        public OcupacaoMap()
        {
            Map(x => x.Descricao);
        }
    }
}