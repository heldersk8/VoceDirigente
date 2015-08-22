using Dominio.Doacoes;
using Dominio.Repositorios;
using Infra._Base.Repositorios;
using NHibernate;

namespace Infra.Repositorios.Dominio
{
    public class DoadorRepositorio : RepositorioBaseDominio<Doador>, IDoadorRepositorio
    {
        public DoadorRepositorio(ISession sessao) : base(sessao) { }
    }
}
