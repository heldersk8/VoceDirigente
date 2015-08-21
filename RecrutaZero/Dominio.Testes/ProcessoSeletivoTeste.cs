using System;
using System.Collections.Generic;
using NUnit.Framework;
using RecrutaZero.Dominio.Excecao;
using RecrutaZero.Dominio.Testes.Builders;
using RecrutaZero.Dominio.Testes.Helpers;

namespace RecrutaZero.Dominio.Testes
{
    [TestFixture]
    public class ProcessoSeletivoTeste
    {
        private string _descricaoDaVaga;
        private string _paraOTime;
        private Ocupacao _ocupacao;
        private ProcessoSeletivo _processoSeletivo;
        private Candidato _candidato;
        private List<CandidatoParaSelecao> _candidatos;
        private CandidatoParaSelecao _candidatoParaSelecao;

        [SetUp]
        public void SetUp()
        {
            _paraOTime = "Desenvolvimento";
            _descricaoDaVaga = "Desenvolvedor experiente";
            _ocupacao = new Ocupacao("Desenvolvedor");
            _processoSeletivo = new ProcessoSeletivo(_ocupacao, _paraOTime, _descricaoDaVaga);
            _candidato = CandidatoBuilder.UmCandidato().ComNome("Nome").Build();
            _candidatoParaSelecao = new CandidatoParaSelecao(_candidato, 1);
            _candidatos = new List<CandidatoParaSelecao> { _candidatoParaSelecao };
        }

        [Test]
        public void DeveCriarUmProcessoSeletivoComOCargo()
        {
            Assert.AreEqual(_processoSeletivo.Ocupacao, _ocupacao);
        }

        [Test]
        public void AoCriarProcessoSeletivoStatusDeveSerPendente()
        {
            Assert.AreEqual(_processoSeletivo.Status, StatusDoProcessoSeletivo.Pendente);
        }

        [Test]
        public void DeveCriarUmProcessoSeletivoParaUmTime()
        {
            Assert.AreEqual(_processoSeletivo.ParaOTime, _paraOTime);
        }

        [Test]
        public void DeveCriarUmProcessoSeletivoComDescricaoDaVaga()
        {
            Assert.AreEqual(_processoSeletivo.DescricaoDaVaga, _descricaoDaVaga);
        }

        [Test]
        public void NaoDevePermitirProcessoSeletivoSemOcupacao()
        {
            Assert.Throws<ExcecaoDeDominio<ProcessoSeletivo>>(() => new ProcessoSeletivo(null, _paraOTime, _descricaoDaVaga)).ComMensagem("Não é possível criar processo seletivo sem a ocupação");
        }

        [Test]
        public void NaoDevePermitirProcessoSeletivoSemOTimeParaOQualEstaSendoSelecionado()
        {
            Assert.Throws<ExcecaoDeDominio<ProcessoSeletivo>>(() => new ProcessoSeletivo(_ocupacao, "", _descricaoDaVaga)).ComMensagem("Não é possível criar processo seletivo sem o Time para qual a pessoa está sendo selecionada");
        }

        [Test]
        public void NaoDevePermitirProcessoSeletivoSemADescricaoDaVaga()
        {
            Assert.Throws<ExcecaoDeDominio<ProcessoSeletivo>>(() => new ProcessoSeletivo(_ocupacao, _paraOTime, "")).ComMensagem("Não é possível criar processo seletivo sem a descrição da vaga");
        }

        [Test]
        public void DeveContratarCandidatoInformandoAData()
        {
            _processoSeletivo = new ProcessoSeletivo(_ocupacao, _paraOTime, _descricaoDaVaga);
            var dataDeContratacao = DateTime.Today;
            _processoSeletivo.Abrir(_candidatos);

            _processoSeletivo.Contratar(_candidatoParaSelecao, dataDeContratacao);

            Assert.AreEqual(_candidatoParaSelecao.Status, StatusDoCandidatoNoProcesso.Contratado);
        }

        [Test]
        public void AoContratarCandidatoDeveMarcarDataDeContratacao()
        {
            _processoSeletivo = new ProcessoSeletivo(_ocupacao, _paraOTime, _descricaoDaVaga);
            var dataDeContratacao = DateTime.Today;
            _processoSeletivo.Abrir(_candidatos);

            _processoSeletivo.Contratar(_candidatoParaSelecao, dataDeContratacao);

            Assert.AreEqual(_candidato.DataDeContratacao, dataDeContratacao);
        }

        [Test]
        public void DeveEncerrarProcessoDeSelecao()
        {
            _processoSeletivo.Abrir(_candidatos);

            _processoSeletivo.Encerrar(DateTime.Today);

            Assert.AreEqual(_processoSeletivo.Status, StatusDoProcessoSeletivo.Finalizado);
        }

        [Test]
        public void DeveDispararExcecaoCasoTenteEncerrarProcessoDeSelecaoComStatusDiferenteDeAberto()
        {
            Assert.Throws<ExcecaoDeDominio<ProcessoSeletivo>>(() => _processoSeletivo.Encerrar(DateTime.Today)).ComMensagem("Não é possível encerrar esse processo seletivo");
        }

        [Test]
        public void AoEncerrarProcessoDeSelecaoDeveInformarDataDeEncerramentoDoProcesso()
        {
            _processoSeletivo.Abrir(_candidatos);
            var dataDeEncerramento = DateTime.Today;

            _processoSeletivo.Encerrar(dataDeEncerramento);

            Assert.AreEqual(_processoSeletivo.DataDeEncerramento, dataDeEncerramento);
        }

        [Test]
        public void NaoDevePermitirEncerramentoComDataFutura()
        {
            _processoSeletivo.Abrir(_candidatos);
            var dataDeEncerramento = DateTime.Today.AddDays(1);

            Assert.Throws<ExcecaoDeDominio<ProcessoSeletivo>>(() => _processoSeletivo.Encerrar(dataDeEncerramento)).ComMensagem("Não é possível encerrar processo seletivo com data futura");
        }
    }
}
