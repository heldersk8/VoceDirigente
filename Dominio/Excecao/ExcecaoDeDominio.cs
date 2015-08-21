using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dominio.Excecao
{
    public class ExcecaoDeDominio : Exception
    {
        private readonly Expression<Func<object, object>> _objeto = x => x;
        protected readonly IList<ViolacaoDeRegra> _erros = new List<ViolacaoDeRegra>();
        public IEnumerable<ViolacaoDeRegra> Erros { get { return _erros; } }

        internal void AdicionarErroAoModelo(string mensagem)
        {
            _erros.Add(new ViolacaoDeRegra { Propriedade = _objeto, Mensagem = mensagem });
        }

        public bool PossuiErroComAMensagemIgualA(string mensagem)
        {
            return Erros.Any(e => e.Mensagem.Equals(mensagem));
        }

        public IEnumerable<string> Mensagens()
        {
            return Erros.Select(x => x.Mensagem);
        }
    }

    public class ExcecaoDeDominio<TModelo> : ExcecaoDeDominio
    {
        internal void AdicionarErroPara<TPropriedade>(Expression<Func<TModelo, TPropriedade>> propriedade, string mensagem)
        {
            _erros.Add(new ViolacaoDeRegra { Propriedade = propriedade, Mensagem = mensagem });
        }
    }

    public static class ExtensoesDeRegrasException
    {
        public static void DispararExcecaoComMensagem(this ExcecaoDeDominio excecaoDeDominio, string mensagem)
        {
            excecaoDeDominio.AdicionarErroAoModelo(mensagem);
            throw excecaoDeDominio;
        }

        public static string MensagensDeErroEmTexto(this ExcecaoDeDominio ex)
        {
            var stringBuilder = new StringBuilder();
            foreach (var erro in ex.Erros)
            {
                stringBuilder.Append(erro.Mensagem);
                stringBuilder.Append("\n");
            }
            return stringBuilder.Length > 0 ? stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString() : stringBuilder.ToString();
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
    }

}
