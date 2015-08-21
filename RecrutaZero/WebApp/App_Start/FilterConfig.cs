using System.Web.Mvc;
using RecrutaZero.WebApp.Filters;

namespace RecrutaZero.WebApp.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new UnitOfWorkAttribute());
            filters.Add(new TratamentoDeExcecoesCustomizadas());
        }
    }
}