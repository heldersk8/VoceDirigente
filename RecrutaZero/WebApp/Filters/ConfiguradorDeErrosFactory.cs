using System;
using RecrutaZero.Dominio.Excecao;

namespace RecrutaZero.WebApp.Filters
{
    public class ConfiguradorDeErrosFactory : IConfiguradorDeErrosFactory
    {
        public IConfiguradorDeErros CriarPara(Exception ex)
        {
            if (ex is ExcecaoDeDominio) return new ConfiguradorDeErrosDeDominio();
            return null;
        }
    }
}