using System.Text;
using System.Web.Mvc;
using RecrutaZero.Dominio.Excecao;

namespace RecrutaZero.WebApp.Filters
{
    public static class ExtensoesDeExcecaoDeDominio
    {
        public static void CopiarErrosPara(this ExcecaoDeDominio ex, ModelStateDictionary modelState, string prefixo = null)
        {
            prefixo = string.IsNullOrWhiteSpace(prefixo) ? "" : prefixo + ".";

            foreach (var erro in ex.Erros)
            {
                var propriedade = ExpressionHelper.GetExpressionText(erro.Propriedade);
                var chave = string.IsNullOrWhiteSpace(propriedade) ? "" : prefixo + propriedade;

                modelState.AddModelError(chave, erro.Mensagem);
            }
        }

        public static string ConverterParaHtml(this ExcecaoDeDominio ex)
        {
            var stringBuilder = new StringBuilder();
            foreach (var erro in ex.Erros)
            {
                stringBuilder.Append(erro.Mensagem);
                stringBuilder.Append("<br/>");
            }
            return stringBuilder.ToString();
        }

        public static string ConverterParaTexto(this ExcecaoDeDominio ex)
        {
            var stringBuilder = new StringBuilder();
            foreach (var erro in ex.Erros)
            {
                stringBuilder.Append(erro.Mensagem);
                stringBuilder.Append("\n");
            }
            return stringBuilder.Length > 0 ? stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString() : stringBuilder.ToString();
        }
    }
}