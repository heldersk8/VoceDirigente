namespace RecrutaZero.WebApp.DependencyInjection
{
    public static class ConfiguradorDeDI
    {
        public static IContainer Container { get; private set; }

        public static IContainer ObterContainer()
        {
            return Container ?? (Container = new NinjectContainerAdapter(new NinjectWebAppModule()));
        }
    }
}
