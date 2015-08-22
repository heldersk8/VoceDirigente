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

        public JsonResult AtualizarLikes(int zagueiroId)
        {
            var numeroDelikes = _jogadorRepositorio.ObterPor(zagueiroId).Likes;

            return Json(numeroDelikes);
        }

        public ActionResult JogadorPerfil(int idDoJogador)
        {
            var jogadorPerfil = _jogadorRepositorio.ObterPor(idDoJogador);
            var viewModel = new JogadorPerfilVm { Jogador = jogadorPerfil };

            return View("PerfilJogador",viewModel);
        }

    }
}