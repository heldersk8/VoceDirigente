using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using RecrutaZero.Dominio.EnvioDeEmail;
using RecrutaZero.Dominio.Testes.Builders;

namespace RecrutaZero.Dominio.Testes
{
    [TestFixture]
    public class AberturaDoProcessoSeletivoTeste
    {
        private string _descricaoDaVaga;
        private Ocupacao _ocupacao;
        private string _time;
        private ProcessoSeletivo _processoSeletivo;
        private Mock<ICandidatoRepositorio> _candidatoRepositorio;
        private AberturaDoProcessoSeletivo _aberturaDoProcessoSeletivo;
        private Candidato _candidato1;
        private List<Candidato> _listaDeCandidatos;
        private Mock<IEnvioDeEmail> _envioDeEmail;
        private Mock<IComunicacaoComFacebook> _comunicacaoComFacebook;

        [SetUp]
        public void SetUp()
        {
            _descricaoDaVaga = "Desenvolvedor experiente";
            _time = "Desenvolvimento";
            _ocupacao = new Ocupacao("Desenvolvedor");
            _processoSeletivo = new ProcessoSeletivo(_ocupacao, _time, _descricaoDaVaga);
            _candidatoRepositorio = new Mock<ICandidatoRepositorio>();

            _candidato1 = CandidatoBuilder.UmCandidato().ComNome("José").ComEmail("a@a.com").ComOrigem("Indicação").ComTelefone("99999999")
               .ComTwitter("@rawr").ComFacebook("facebook.com/x").ComLinkedIn("linkedin.com/x").ComSitePessoal("github.com/x").Build();
            _envioDeEmail = new Mock<IEnvioDeEmail>();
            _comunicacaoComFacebook = new Mock<IComunicacaoComFacebook>();
            _aberturaDoProcessoSeletivo = new AberturaDoProcessoSeletivo(_candidatoRepositorio.Object, _envioDeEmail.Object,_comunicacaoComFacebook.Object);
            _listaDeCandidatos = new List<Candidato> { _candidato1 };
        }

        [Test]
        public void DeveAbrirUmProcessoSeletivo()
        {
            _aberturaDoProcessoSeletivo.Abrir(_processoSeletivo);

            Assert.AreEqual(_processoSeletivo.Status, StatusDoProcessoSeletivo.EmAndamento);
        }

        [Test]
        public void DeveFiltarCandidatosPelaOcupacao()
        {
            _aberturaDoProcessoSeletivo.Abrir(_processoSeletivo);

            _candidatoRepositorio.Verify(x => x.ObterTodosOsCandidatosPara(_ocupacao), Times.Once());
        }

        [Test]
        public void DeveInserirCandidatosNaAberturaDoProcesso()
        {
            _candidatoRepositorio.Setup(x => x.ObterTodosOsCandidatosPara(_ocupacao)).Returns(_listaDeCandidatos);

            _aberturaDoProcessoSeletivo.Abrir(_processoSeletivo);
            var candidatoParaVaga = _processoSeletivo.Candidatos.FirstOrDefault();

            Assert.AreEqual(candidatoParaVaga.Nome, _candidato1.Nome);
        }

        [Test]
        public void DeveEnviarEmailParaTodosOsCandidatos()
        {
            _candidatoRepositorio.Setup(x => x.ObterTodosOsCandidatosPara(_ocupacao)).Returns(_listaDeCandidatos);

            _aberturaDoProcessoSeletivo.Abrir(_processoSeletivo);

            _envioDeEmail.Verify(x => x.Enviar(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(_processoSeletivo.Candidatos.Count()));
        }


        [Test]
        public void DevePostarAVagaNoFacebookComONomeDaOcupacao()
        {
            var mensagem = string.Format("Vaga para {0}", _processoSeletivo.Ocupacao.Descricao);

            _aberturaDoProcessoSeletivo.Abrir(_processoSeletivo);

            _comunicacaoComFacebook.Verify(x => x.Postar(mensagem), Times.Once());
        }

        [Test]
        public void AoAbrirProcessoSeletivoDeveBuscarApenasCandidatosNaoContratados()
        {
            _aberturaDoProcessoSeletivo.Abrir(_processoSeletivo);

            _candidatoRepositorio.Verify(x => x.ObterTodosOsCandidatosPara(_ocupacao), Times.Once());
        }

        [Test]
        public void AoAbrirProcessoSeletivoDeveSetarDataDeAberturaDoProcessoSeletivo()
        {
            _aberturaDoProcessoSeletivo.Abrir(_processoSeletivo);

            Assert.AreEqual(_processoSeletivo.DataDeInicio,DateTime.Today);
        }
    }
}
