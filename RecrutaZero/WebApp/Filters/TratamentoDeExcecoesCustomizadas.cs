using System.Web.Mvc;

namespace RecrutaZero.WebApp.Filters
{
    public class TratamentoDeExcecoesCustomizadas : IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            var configuradorDeErros = (new ConfiguradorDeErrosFactory()).CriarPara(exceptionContext.Exception);
            if (configuradorDeErros == null) return;

            exceptionContext.Result = CriarActionResult(exceptionContext, configuradorDeErros);
            exceptionContext.ExceptionHandled = true;
        }

        private static ActionResult CriarActionResult(ExceptionContext exceptionContext, IConfiguradorDeErros configuradorDeErros)
        {
            if (exceptionContext.HttpContext.Request.IsAjaxRequest())
                return new JsonResult { Data = new { excecoes = configuradorDeErros.RetornarErros(exceptionContext.Exception) } };

            var viewResult = new ViewResult { ViewData = exceptionContext.Controller.ViewData, TempData = exceptionContext.Controller.TempData };
            configuradorDeErros.AtribuirErrosAoModelState(exceptionContext.Exception, viewResult.ViewData.ModelState);
            return viewResult;
        }
    }
}