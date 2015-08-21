using System.Web.Mvc;
using RecrutaZero.Dominio.EnvioDeEmail;

namespace RecrutaZero.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnvioDeEmail _envioDeEmail;
        private readonly IComunicacaoComFacebook _comunicacaoComFacebook;

        public HomeController(IEnvioDeEmail envioDeEmail, IComunicacaoComFacebook comunicacaoComFacebook)
        {
            _envioDeEmail = envioDeEmail;
            _comunicacaoComFacebook = comunicacaoComFacebook;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return RedirectToAction("Index", "ProcessoSeletivo");
        }

        public ActionResult About()
        {
            _envioDeEmail.EnviarEmailDuMau("sandro", "sandro.oyadomari@gmail.com");
            //_comunicacaoComFacebook.Postar("Mensagem de teste");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
