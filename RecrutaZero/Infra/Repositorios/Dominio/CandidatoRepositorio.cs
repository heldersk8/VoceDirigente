using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RecrutaZero.Dominio;
using RecrutaZero.Infra._Base.Repositorios;

namespace RecrutaZero.Infra.Repositorios.Dominio
{
    public class CandidatoRepositorio : RepositorioBaseDominio<Candidato>, ICandidatoRepositorio
    {
        public CandidatoRepositorio(ISession sessao) : base(sessao) { }

        public IEnumerable<Candidato> ObterTodosOsCandidatosPara(Ocupacao ocupacao)
        {
            return Entidades().Where(x => x.Ocupacao.Id == ocupacao.Id && x.Status != StatusDoCandidato.Contratado).ToList();
        }
    }
}