using System.Reflection;
using NHibernate.Context;
using RecrutaZero.Infra._Base.Configuracoes;

namespace RecrutaZero.Infra.SessionFactory
{
    public class ConfiguradorDeSessionFactory : ConfiguradorDeSessionFactory<WebSessionContext>
    {
        public ConfiguradorDeSessionFactory()
        {
            CurrentAssembly = Assembly.GetExecutingAssembly();
        }
    }
}