using Dominio.Excecao;
using NUnit.Framework;
using System.Text;

namespace RecrutaZero.Dominio.Testes.Helpers
{
    public static class AssertExtensions
    {
        public static void ComMensagem(this ExcecaoDeDominio exception, string message)
        {
            if (exception.PossuiErroComAMensagemIgualA(message))
                Assert.Pass("Disparou exceção com a mensagem correta: {0}", message);
            else
            {
                var mensagemDeFalha = MontarMensagemDeFalha(exception, message);
                Assert.Fail(mensagemDeFalha.ToString());
            }
        }

        private static StringBuilder MontarMensagemDeFalha(ExcecaoDeDominio exception, string message)
        {
            var mensagens = exception.Mensagens();
            var mensagemDeFalha = new StringBuilder();

            mensagemDeFalha.AppendLine(string.Format("Não disparou exceção com a mensagem: {0}", message));

            foreach (var mensagem in mensagens)
                mensagemDeFalha.AppendLine(string.Format("E exibiu a seguinte mensagem:        {0}", mensagem));

            return mensagemDeFalha;
        }
    }
}
