using Dominio.Doacoes;
using Dominio.Repositorios;
using Infra._Base.Repositorios;
using NHibernate;

namespace Infra.Repositorios.Dominio
{
    public class DoacaoRepositorio : RepositorioBaseDominio<Doacao>, IDoacaoRepositorio
    {
        public DoacaoRepositorio(ISession sessao) : base(sessao) { }
    }
}