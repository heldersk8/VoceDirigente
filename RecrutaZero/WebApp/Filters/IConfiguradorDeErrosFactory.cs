using System;

namespace RecrutaZero.WebApp.Filters
{
    public interface IConfiguradorDeErrosFactory
    {
        IConfiguradorDeErros CriarPara(Exception ex);
    }
}