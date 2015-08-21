using System.Web.Mvc;
using Dominio.Repositorios;

namespace ODirigente.Controllers
{
    public class FlamengoController : Controller
    {
        private IJogadorRepositorio _jogadorRepositorio;

        public FlamengoController(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;

        }

        public ActionResult Index()
        {
            var todos = _jogadorRepositorio.ObterTodos();

            return View();
        }

    }
}