using Dominio.Doacoes;
using Infra._Base.Mapeamentos;

namespace Infra.Mapeamentos
{
    public class DoadorMap : MapBase<Doador>
    {
        public DoadorMap()
        {
            Map(x => x.Nome);
            Map(x => x.CartaoDeCredito);
        }
    }
}
