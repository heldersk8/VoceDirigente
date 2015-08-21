using System;
using System.Linq;
using System.Web.Mvc;
using RecrutaZero.Dominio;
using RecrutaZero.WebApp.ViewModels;

namespace RecrutaZero.WebApp.Controllers
{
    public class ProcessoSeletivoController : Controller
    {
        private readonly AberturaDoProcessoSeletivo _aberturaDoProcessoSeletivo;
        private readonly ClassificarAptidao _classificarAptidao;
        private readonly IOcupacaoRepositorio _ocupacaoRepositorio;
        private readonly IProcessoSeletivoRepositorio _processoSeletivoRepositorio;
        private readonly IServicoParaContratarCandidato _servicoParaContratarCandidato;
        private readonly ICandidatoParaSelecaoRepositorio _candidatoParaSelecaoRepositorio;
        private readonly IEncerramentoDeProcessoSeletivo _encerramentoDeProcessoSeletivo;

        public ProcessoSeletivoController(AberturaDoProcessoSeletivo aberturaDoProcessoSeletivo, ClassificarAptidao classificarAptidao,
            IOcupacaoRepositorio ocupacaoRepositorio, IProcessoSeletivoRepositorio processoSeletivoRepositorio,
            IServicoParaContratarCandidato servicoParaContratarCandidato, ICandidatoParaSelecaoRepositorio candidatoParaSelecaoRepositorio,
            IEncerramentoDeProcessoSeletivo encerramentoDeProcessoSeletivo)
        {
            _aberturaDoProcessoSeletivo = aberturaDoProcessoSeletivo;
            _classificarAptidao = classificarAptidao;
            _ocupacaoRepositorio = ocupacaoRepositorio;
            _processoSeletivoRepositorio = processoSeletivoRepositorio;
            _servicoParaContratarCandidato = servicoParaContratarCandidato;
            _candidatoParaSelecaoRepositorio = candidatoParaSelecaoRepositorio;
            _encerramentoDeProcessoSeletivo = encerramentoDeProcessoSeletivo;
        }

        public ActionResult Index()
        {
            var consultaDeProcessoSeletivoVm = new ConsultaDeProcessoSeletivoVm
            {
                Ocupacoes = _ocupacaoRepositorio.ObterTodos().Select(x => new OcupacaoVm { Id = x.Id, Descricao = x.Descricao }).OrderBy(x => x.Descricao)
            };

            return View(consultaDeProcessoSeletivoVm);
        }

        public ActionResult Consultar(ConsultaDeProcessoSeletivoVm consultaDeProcessoSeletivoVm)
        {
            var processosSeletivos = consultaDeProcessoSeletivoVm.OcupacaoId == 0
                ? _processoSeletivoRepositorio.ObterTodos()
                : _processoSeletivoRepositorio.ObterPorOcupacao(consultaDeProcessoSeletivoVm.OcupacaoId);

            return View("ResultadosDaPesquisa", processosSeletivos.OrderBy(x => x.Id));
        }

        public ActionResult Incluir()
        {
            var processoSeletivo = new ProcessoSeletivoVm
            {
                Ocupacoes = _ocupacaoRepositorio.ObterTodos().Select(x => new OcupacaoVm { Id = x.Id, Descricao = x.Descricao }).OrderBy(x => x.Descricao)
            };

            return View(processoSeletivo);
        }

        [HttpPost]
        public ActionResult Index(ProcessoSeletivoVm processoSeletivoVm)
        {
            var ocupacao = _ocupacaoRepositorio.ObterPor(processoSeletivoVm.OcupacaoId);
            var processoSeletivo = new ProcessoSeletivo(ocupacao, processoSeletivoVm.ParaOTime, processoSeletivoVm.DescricaoDaVaga);

            _processoSeletivoRepositorio.Adicionar(processoSeletivo);

            TempData["MensagemDeSucesso"] = "Processo seletivo salvo com sucesso";

            return RedirectToAction("Index");
        }

        public ActionResult Visualizar(int id)
        {
            var processoSeletivo = _processoSeletivoRepositorio.ObterPor(id);

            var vm = new CandidatosParaSelecaoPorProcessoVm { ProcessoSeletivoId = id, ProcessoStatus = processoSeletivo.Status, CandidatosParaSelecao = processoSeletivo.Candidatos, DescricaoDaVaga = processoSeletivo.Ocupacao.Descricao };

            return View(vm);
        }

        public ActionResult Abrir(int id)
        {
            var processoSeletivo = _processoSeletivoRepositorio.ObterPor(id);

            _aberturaDoProcessoSeletivo.Abrir(processoSeletivo);

            return RedirectToAction("Index");
        }

        public ActionResult ConsultarCandidatoParaSelecao(int processoSeletivoId, string nome)
        {
            var processoSeletivo = _processoSeletivoRepositorio.ObterPor(processoSeletivoId);

            var vm = new CandidatosParaSelecaoPorProcessoVm { ProcessoSeletivoId = processoSeletivoId, ProcessoStatus = processoSeletivo.Status, CandidatosParaSelecao = processoSeletivo.Candidatos.Where(x => x.Nome.Contains(nome)), DescricaoDaVaga = processoSeletivo.Ocupacao.Descricao };

            return View("Visualizar", vm);
        }

        public PartialViewResult Aptidoes(int processoSeletivoId, int candidatoParaSelecaoId)
        {
            var candidatoParaSelecao = _candidatoParaSelecaoRepositorio.ObterPor(candidatoParaSelecaoId);

            return PartialView("Aptidoes", candidatoParaSelecao);
        }

        [HttpPost]
        public void SalvarAptidao(int candidatoParaSelecaoId, int passoId, string observacao, DateTime data, bool apto)
        {
            var passo = TodosOsPassos.ListarTodos.FirstOrDefault(x => x.Id == passoId);
            var candidatoParaSelecao = _candidatoParaSelecaoRepositorio.ObterPor(candidatoParaSelecaoId);

            _classificarAptidao.Salvar(candidatoParaSelecao, passo, observacao, data, apto);
        }

        public void Contratar(int processoSeletivoId, int candidatoParaSelecaoId)
        {
            var candidatoParaSelecao = _candidatoParaSelecaoRepositorio.ObterPor(candidatoParaSelecaoId);
            var processoSeletivo = _processoSeletivoRepositorio.ObterPor(processoSeletivoId);

            processoSeletivo.Contratar(candidatoParaSelecao, DateTime.Now);
            _servicoParaContratarCandidato.MarcarCandidatoComoContratado(candidatoParaSelecao.Candidato);
        }

        public void Encerrar(int processoSeletivoId)
        {
            var processoSeletivo = _processoSeletivoRepositorio.ObterPor(processoSeletivoId);

            _encerramentoDeProcessoSeletivo.Encerrar(processoSeletivo, DateTime.Now);
        }
    }
}
