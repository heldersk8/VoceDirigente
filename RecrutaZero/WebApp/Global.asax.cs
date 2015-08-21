using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RecrutaZero.WebApp.App_Start;
using RecrutaZero.WebApp.DependencyInjection;
using RecrutaZero.WebApp.EventHandlers;
using RecrutaZero.WebApp.Helpers.ModelBinders;
using RecrutaZero.WebApp.Infra.DI;

namespace RecrutaZero.WebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private IContainer _container;

        protected void Application_Start()
        {
            ConfigurarContainer();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigurarInjecaoDeDependencia();
            ConfigurarOrm();
            ConfigurarModelBinders();
        }

        private void ConfigurarContainer()
        {
            _container = ConfiguradorDeDI.ObterContainer();
        }

        private static void ConfigurarOrm()
        {
            ConfiguradorDeOrm.Configurar();
        }

        private void ConfigurarInjecaoDeDependencia()
        {
            ControllerBuilder.Current.SetControllerFactory(new RecrutaZeroWebAppControllerFactory(_container));
        }

        private static void ConfigurarModelBinders()
        {
            ModelBinders.Binders.Add(typeof(string), new StringModelBinder());
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