using System.Web.Mvc;
using Infra.DI;
using WebGrease.Css.Extensions;

namespace ODirigente.Infra
{
    public class FilterDIProvider : ControllerActionInvoker
    {
        private readonly IContainer _container;

        public FilterDIProvider(IContainer container)
        {
            _container = container;
        }

        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var info = base.GetFilters(controllerContext, actionDescriptor);

            info.AuthorizationFilters.ForEach(_container.BuildUp);
            info.ActionFilters.ForEach(_container.BuildUp);
            info.ResultFilters.ForEach(_container.BuildUp);
            info.ExceptionFilters.ForEach(_container.BuildUp);

            return info;
        }
    }
}