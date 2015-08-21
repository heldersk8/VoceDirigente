using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RecrutaZero.WebApp.DependencyInjection
{
    internal class RecrutaZeroWebAppControllerFactory : DefaultControllerFactory
    {
        private readonly IContainer _container;

        public RecrutaZeroWebAppControllerFactory(IContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                throw new HttpException(404, "Controller not found.");

            var controller = (IController)_container.Get(controllerType);

            AtribuirActionInvoker(controllerType, controller);

            return controller;
        }

        private void AtribuirActionInvoker(Type controllerType, IController controller)
        {
            if (!typeof(Controller).IsAssignableFrom(controllerType)) return;

            var controllerInstance = controller as Controller;

            if (controllerInstance != null)
                controllerInstance.ActionInvoker = new FilterDIProvider(_container);
        }
    }
}