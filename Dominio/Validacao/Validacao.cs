using Dominio.Excecao;
using Dominio.Extensoes;
using System;

namespace Dominio.Validacao
{
    public class Validacao<T> where T : class
    {
        public static void EhObrigatorio(string valor, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(valor))
                new ExcecaoDeDominio<T>().DispararExcecaoComMensagem(mensagem);
        }

        public static void EhObrigatorio(int valor, string mensagem)
        {
            if (valor <= 0)
                new ExcecaoDeDominio<T>().DispararExcecaoComMensagem(mensagem);
        }

        public static void EhObrigatorio(decimal valor, string mensagem)
        {
            if (valor <= 0)
                new ExcecaoDeDominio<T>().DispararExcecaoComMensagem(mensagem);
        }

        public static void Quando(bool condicao, string mensagem)
        {
            if (condicao)
                new ExcecaoDeDominio<T>().DispararExcecaoComMensagem(mensagem);
        }

        public static void EhObrigatorio<TZ>(TZ entidade, string mensagem)
        {
            if (null == entidade)
                new ExcecaoDeDominio<T>().DispararExcecaoComMensagem(mensagem);
        }

        public static void EhObrigatorio(DateTime data, string mensagem)
        {
            if (!data.DataValida())
                new ExcecaoDeDominio<T>().DispararExcecaoComMensagem(mensagem);
        }
    }
}
