using System;
using System.Web.Mvc;

namespace RecrutaZero.WebApp.Filters
{
    public interface IConfiguradorDeErros
    {
        string RetornarErros(Exception ex);
        void AtribuirErrosAoModelState(Exception ex, ModelStateDictionary modelState);
    }
}