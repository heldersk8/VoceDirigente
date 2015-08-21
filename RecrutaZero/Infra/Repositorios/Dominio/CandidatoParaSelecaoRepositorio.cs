using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RecrutaZero.Dominio;
using RecrutaZero.Dominio.Repositorios;
using RecrutaZero.Infra._Base.Repositorios;

namespace RecrutaZero.Infra.Repositorios.Dominio
{
    public class CandidatoParaSelecaoRepositorio : RepositorioBaseDominio<CandidatoParaSelecao>, ICandidatoParaSelecaoRepositorio
    {
        public CandidatoParaSelecaoRepositorio(ISession sessao) : base(sessao) { }

        public IEnumerable<CandidatoParaSelecao> ObterPor(Candidato candidato)
        {
            return Entidades().Where(x => x.Candidato == candidato);
        }
    }
}
