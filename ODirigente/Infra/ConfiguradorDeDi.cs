using Infra.DI;

namespace ODirigente.Infra
{
    public static class ConfiguradorDeDI
    {
        public static IContainer Container { get; private set; }

        public static IContainer ObterContainer()
        {
            Container = Container ?? new NinjectContainerAdapter(new NinjectWebAppModule());
            return Container;
        }
    }
}