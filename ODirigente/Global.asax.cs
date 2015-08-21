using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Infra.DI;
using ODirigente.Infra;

namespace ODirigente
{
    public class MvcApplication : HttpApplication
    {
        private IContainer _container;

        protected void Application_Start()
        {
            ConfigurarContainer();
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DefaultModelBinder.ResourceClassKey = "Mensagens";
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigurarOrm();
            ConfigurarInjecaoDeDependencia();
        }


        private void ConfigurarContainer()
        {
            _container = ConfiguradorDeDI.ObterContainer();
        }

        private void ConfigurarInjecaoDeDependencia()
        {
            ControllerBuilder.Current.SetControllerFactory(new DirigenteControllerFactory(_container));
        }

        private static void ConfigurarOrm()
        {
            ConfiguradorDeOrm.Configurar();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            EventosWeb.RecebendoChamada();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            EventosWeb.EncerrandoChamada();
        }
    }
}
