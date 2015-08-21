using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace RecrutaZero.Infra._Base.Configuracoes
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column("Id");
        }
    }
}