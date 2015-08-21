using NHibernate;
using RecrutaZero.Dominio;
using RecrutaZero.Dominio.Repositorios;
using RecrutaZero.Infra._Base.Repositorios;

namespace RecrutaZero.Infra.Repositorios.Dominio
{
    public class OcupacaoRepositorio : RepositorioBaseDominio<Ocupacao>, IOcupacaoRepositorio
    {
        public OcupacaoRepositorio(ISession sessao) : base(sessao) { }

        public void Adicionar(Ocupacao entidade)
        {
            throw new System.NotImplementedException();
        }
    }
}