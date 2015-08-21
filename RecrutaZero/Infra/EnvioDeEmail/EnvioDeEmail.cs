using System.Net.Mail;
using System.Text;
using RecrutaZero.Dominio.EnvioDeEmail;
using RecrutaZero.Infra.Helpers;

namespace RecrutaZero.Infra.EnvioDeEmail
{
    public class EnvioDeEmail : IEnvioDeEmail
    {
        private static ILeitorDeTemplateDeEmail _leitorDeTemplateDeEmail;

        public EnvioDeEmail(ILeitorDeTemplateDeEmail leitorDeTemplateDeEmail)
        {
            _leitorDeTemplateDeEmail = leitorDeTemplateDeEmail;
        }

        private static void ValidarEnvio(string nome, string emailDeDestinatario)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new EnvioDeEmailException("Nome do destinatário deve ser informado");

            if (string.IsNullOrWhiteSpace(emailDeDestinatario))
                throw new EnvioDeEmailException("E-mail do destinatário deve ser informado");
        }

        //TODO:Mudar a template do email
        public void Enviar(string nome, string emailDeDestinatario)
        {
            ValidarEnvio(nome, emailDeDestinatario);

            var remetente = new MailAddress("dtalentos@digithobrasil.com", "Recrutamento DigithoBrasil");
            var destinatario = new MailAddress(emailDeDestinatario, nome);

            var corpoDoEmail = MontarCorpoDoEmail(nome);

            using (var smtp = new SmtpClient())
            {
                using (var mensagem = new MailMessage(remetente, destinatario) { Subject = "Oportunidades", IsBodyHtml = true, BodyEncoding = Encoding.UTF8, Body = corpoDoEmail })
                    smtp.Send(mensagem);
            }
        }

        public void EnviarEmailDuMau(string nome, string emailDeDestinatario)
        {
            ValidarEnvio(nome, emailDeDestinatario);

            var remetente = new MailAddress("dtalentos@digithobrasil.com", "Recrutamento DigithoBrasil");
            var destinatario = new MailAddress(emailDeDestinatario, nome);

            var corpoDoEmail = MontarCorpoDoEmailDuMau(nome);

            using (var smtp = new SmtpClient())
            {
                using (var mensagem = new MailMessage(remetente, destinatario) { Subject = "Oportunidades", IsBodyHtml = true, BodyEncoding = Encoding.UTF8, Body = corpoDoEmail })
                    smtp.Send(mensagem);
            }

        }

        private string MontarCorpoDoEmailDuMau(string nome)
        {
            var corpoDoEmail = _leitorDeTemplateDeEmail.LerEmailDuMau();
            var novoCorpoDoEmail = corpoDoEmail.Replace("@Candidato@", nome);
            novoCorpoDoEmail = novoCorpoDoEmail.Replace("@CaminhoDasImagens@", ConfiguracoesGlobais.CaminhoDeImagensDoTemplateDeEmail);

            return novoCorpoDoEmail;
        }

        public static string MontarCorpoDoEmail(string nome)
        {
            var corpoDoEmail = _leitorDeTemplateDeEmail.Ler();
            var novoCorpoDoEmail = corpoDoEmail.Replace("@Usuario@", nome);
            novoCorpoDoEmail = novoCorpoDoEmail.Replace("@CaminhoDasImagens@", ConfiguracoesGlobais.CaminhoDeImagensDoTemplateDeEmail);

            return novoCorpoDoEmail;
        }
    }
}
