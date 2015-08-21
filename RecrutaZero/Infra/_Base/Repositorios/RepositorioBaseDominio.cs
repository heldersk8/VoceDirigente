using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using RecrutaZero.Dominio.Comum;
using RecrutaZero.Dominio.Specifications;

namespace RecrutaZero.Infra._Base.Repositorios
{
    public abstract class RepositorioBaseDominio<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        protected ISession Sessao { get; private set; }

        protected RepositorioBaseDominio(ISession sessao)
        {
            Sessao = sessao;
        }

        protected IQueryable<TEntidade> Entidades()
        {
            return Sessao.Query<TEntidade>();
        }

        protected IEnumerable<TEntidade> Enumerar()
        {
            return Sessao.CreateCriteria(typeof(TEntidade)).List<TEntidade>();
        }

        public TEntidade ObterPor(int id)
        {
            return Sessao.Get<TEntidade>(id);
        }

        public IEnumerable<TEntidade> ObterPor(ISpecification<TEntidade> specification)
        {
            throw new System.NotImplementedException();
        }

        public virtual IEnumerable<TEntidade> ObterTodos()
        {
            return Entidades().ToList();
        }

        public void Adicionar(TEntidade entidade)
        {
            Sessao.SaveOrUpdate(entidade);
        }

        public void Remover(TEntidade entidade)
        {
            Sessao.Delete(entidade);
        }
    }
}