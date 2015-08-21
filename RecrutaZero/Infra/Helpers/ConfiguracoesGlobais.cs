using System.Web.Configuration;

namespace RecrutaZero.Infra.Helpers
{
    public static class ConfiguracoesGlobais
    {
        public static string CaminhoDeImagensDoTemplateDeEmail { get { return WebConfigurationManager.AppSettings["CaminhoDeImagensDoTemplateDeEmail"]; } }
    }
}