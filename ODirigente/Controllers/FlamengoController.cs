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
        private readonly IDadosDaCarreiraRepositorio _dadosDaCarreiraRepositorio;

        public FlamengoController(IJogadorRepositorio jogadorRepositorio, IDoadorRepositorio doadorRepositorio, IDadosDaCarreiraRepositorio dadosDaCarreiraRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
            _doadorRepositorio = doadorRepositorio;
            _dadosDaCarreiraRepositorio = dadosDaCarreiraRepositorio;
        }

        public ActionResult Index()
        {
            var todos = _jogadorRepositorio.ObterTodos();

            return View(todos);
        }

        public ActionResult Campanhas()
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
            var dadosDaCarreira = _dadosDaCarreiraRepositorio.ObterPor(idDoJogador);
            var viewModel = new JogadorPerfilVm { Jogador = jogadorPerfil, DadosDaCarreira = dadosDaCarreira };

            return View("PerfilJogador", viewModel);
        }

        public JsonResult Doar(decimal valorDaDoacao, int idJogador)
        {
            var jogador = _jogadorRepositorio.ObterPor(idJogador);
            var doador = _doadorRepositorio.ObterPor(1);
            var doacao = new Doacao(doador, valorDaDoacao);

            jogador.Efetuar(doacao);

            return Json(new { Mensagem = "Obrigado pela sua Doação!!!" });
        }

        public JsonResult AtualizarDoacao()
        {
            var jogadores = _jogadorRepositorio.ObterTodos();

            return Json(new { Jogadores = jogadores }, JsonRequestBehavior.AllowGet);
        }

    }
}