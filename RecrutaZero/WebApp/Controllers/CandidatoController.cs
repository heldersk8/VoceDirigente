using System.Linq;
using System.Web.Mvc;
using RecrutaZero.Dominio;
using RecrutaZero.WebApp.ViewModels;

namespace RecrutaZero.WebApp.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ICandidatoRepositorio _candidatoRepositorio;

        public CandidatoController(ICandidatoRepositorio candidatoRepositorio)
        {
            _candidatoRepositorio = candidatoRepositorio;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir()
        {
            return View();
        }

        public ActionResult Consultar(ConsultaDeCandidatoVm consultaDeCandidatoVm)
        {
            var processosSeletivos = _candidatoRepositorio.ObterPor(consultaDeCandidatoVm.Specification());

            return View("ResultadosDaPesquisa", processosSeletivos.OrderBy(x => x.Nome));
        }
    }
}
