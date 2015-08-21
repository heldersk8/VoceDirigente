using System.IO;
using System.Web;
using RecrutaZero.Dominio.EnvioDeEmail;

namespace RecrutaZero.Infra.EnvioDeEmail
{
    public class LeitorDeTemplateDeEmail : ILeitorDeTemplateDeEmail
    {
        public string Ler()
        {
            var arquivo = string.Format("{0}{1}",HttpContext.Current.Server.MapPath("~/App_Data/Email") ,"\\TemplateDeEmail.html");

            return File.OpenText(arquivo).ReadToEnd();
        }

        public string LerEmailDuMau()
        {
            var arquivo = string.Format("{0}{1}", HttpContext.Current.Server.MapPath("~/App_Data/Email"), "\\TemplateDoEmailMau.html");

            return File.OpenText(arquivo).ReadToEnd();
        }
    }
}