using FluentNHibernate.Mapping;
using RecrutaZero.Dominio.Comum;

namespace RecrutaZero.Infra._Base.Mapeamentos
{
    public class MapBase<TEntidade> : ClassMap<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        public MapBase()
        {
            Id(x => x.Id);
        }
    }
}