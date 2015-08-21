using NHibernate;
using RecrutaZero.Dominio;
using RecrutaZero.Infra._Base.Repositorios;

namespace RecrutaZero.Infra.Dao
{
    public class FacebookAccessTokenRepositorio : RepositorioBaseDominio<FacebookToken>, IFacebookTokenRepositorio
    {
        public FacebookAccessTokenRepositorio(ISession sessao) : base(sessao) { }

        public string ObterToken()
        {
            return ObterPor(1).Token;
        }
    }
}