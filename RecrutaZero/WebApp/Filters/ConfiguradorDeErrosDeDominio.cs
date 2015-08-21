using System;
using System.Web.Mvc;
using RecrutaZero.Dominio.Excecao;

namespace RecrutaZero.WebApp.Filters
{
    public class ConfiguradorDeErrosDeDominio : IConfiguradorDeErros
    {
        public string RetornarErros(Exception ex)
        {
            return ((ExcecaoDeDominio)ex).ConverterParaTexto();
        }

        public void AtribuirErrosAoModelState(Exception ex, ModelStateDictionary modelState)
        {
            ((ExcecaoDeDominio)ex).CopiarErrosPara(modelState);
        }
    }
}