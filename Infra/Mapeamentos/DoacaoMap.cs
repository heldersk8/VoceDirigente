using Dominio.Doacoes;
using Infra._Base.Mapeamentos;

namespace Infra.Mapeamentos
{
    public class DoacaoMap : MapBase<Doacao>
    {
        public DoacaoMap()
        {
            Map(x => x.Valor);
            References(x => x.Doador);
            References(x => x.Jogador);
        }
    }
}
