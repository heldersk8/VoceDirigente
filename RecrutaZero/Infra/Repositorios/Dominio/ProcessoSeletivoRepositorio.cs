using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RecrutaZero.Dominio;
using RecrutaZero.Dominio.Repositorios;
using RecrutaZero.Infra._Base.Repositorios;

namespace RecrutaZero.Infra.Repositorios.Dominio
{
    public class ProcessoSeletivoRepositorio : RepositorioBaseDominio<ProcessoSeletivo>, IProcessoSeletivoRepositorio
    {
        public ProcessoSeletivoRepositorio(ISession sessao) : base(sessao) { }

        public IEnumerable<ProcessoSeletivo> ObterPorOcupacao(int ocupacaoId)
        {
            return Entidades().Where(x => x.Ocupacao.Id == ocupacaoId);
        }
    }
}