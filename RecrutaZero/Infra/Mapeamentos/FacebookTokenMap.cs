using RecrutaZero.Dominio;
using RecrutaZero.Infra._Base.Mapeamentos;

namespace RecrutaZero.Infra.Mapeamentos
{
    public class FacebookTokenMap : MapBase<FacebookToken>
    {
        public FacebookTokenMap()
        {
            Map(x => x.Token);
        }
    }
}