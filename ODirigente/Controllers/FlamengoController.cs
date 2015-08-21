using Dominio.Repositorios;
using ODirigente.ViewModels;
using System.Web.Mvc;

namespace ODirigente.Controllers
{
    public class FlamengoController : Controller
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;

        public FlamengoController(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;

        }

        public ActionResult Index()
        {
            var todos = _jogadorRepositorio.ObterTodos();

            return View(todos);
        }

        public ActionResult JogadoresPorPosicao(int posicao)
        {
            var jogadoresPorPosicao = _jogadorRepositorio.ObterPorPosicao(posicao);
            var viewModel = new JogadorPorPosicaoVm { Jogadores = jogadoresPorPosicao };

            return View(viewModel);
        }

        public JsonResult LikeNaZagueirada(int zagueiroId)
        {
            var zagueiro = _jogadorRepositorio.ObterPor(zagueiroId);

            zagueiro.DarUmLike();
            _jogadorRepositorio.Salvar(zagueiro);

            return Json(zagueiro.Likes);
        }
    }
}