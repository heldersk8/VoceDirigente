using Dominio.Comum;
using FluentNHibernate.Mapping;

namespace Infra._Base.Mapeamentos
{
    public class MapBase<TEntidade> : ClassMap<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        public MapBase()
        {
            Id(x => x.Id);
        }
    }
}