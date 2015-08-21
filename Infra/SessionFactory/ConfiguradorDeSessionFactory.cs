using Infra._Base.Configuracoes;
using NHibernate.Context;
using System.Reflection;

namespace Infra.SessionFactory
{
    public class ConfiguradorDeSessionFactory : ConfiguradorDeSessionFactory<WebSessionContext>
    {
        public ConfiguradorDeSessionFactory()
        {
            CurrentAssembly = Assembly.GetExecutingAssembly();
        }
    }
}