using Dominio.Doacoes;
using Dominio.Repositorios;
using ODirigente.ViewModels;
using System.Web.Mvc;

namespace ODirigente.Controllers
{
    public class FlamengoController : Controller
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;
        private readonly IDoadorRepositorio _doadorRepositorio;
        private readonly IDoacaoRepositorio _doacaoRepositorio;

        public FlamengoController(IJogadorRepositorio jogadorRepositorio, IDoadorRepositorio doadorRepositorio, IDoacaoRepositorio doacaoRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
            _doadorRepositorio = doadorRepositorio;
            _doacaoRepositorio = doacaoRepositorio;
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

            return View("PerfilJogador", viewModel);
        }

        public JsonResult Doar(decimal valorDaDoacao, int idJogador)
        {
            var jogador = _jogadorRepositorio.ObterPor(idJogador);
            var doador = _doadorRepositorio.ObterPor(1);
            var doacao = new Doacao(doador, valorDaDoacao);

            return Json(new { Mensagem = "Obrigado pela sua Doação!!!" });
        }
    }
}