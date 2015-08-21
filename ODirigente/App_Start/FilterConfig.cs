using System.Web.Mvc;
using ODirigente.Infra;

namespace ODirigente
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new UnitOfWorkAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
