using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RecrutaZero.Dominio.Testes.Builders;

namespace RecrutaZero.Dominio.Testes
{
    [TestFixture]
    public class ServicoParaContratarCandidatoTeste
    {
        private Mock<ICandidatoParaSelecaoRepositorio> _candidatoParaSelecaoRepositorio;
        private ServicoParaContratarCandidato _servicoParaContratarCandidato;
        private Candidato _canditato;
        private CandidatoParaSelecao _candidatoParaSelecao;
        private List<CandidatoParaSelecao> _candidatosParaSelecao;

        [SetUp]
        public void SetUp()
        {
            _candidatoParaSelecaoRepositorio = new Mock<ICandidatoParaSelecaoRepositorio>();
            _servicoParaContratarCandidato = new ServicoParaContratarCandidato(_candidatoParaSelecaoRepositorio.Object);
            _canditato = CandidatoBuilder.UmCandidato().Build();
            _candidatoParaSelecao = new CandidatoParaSelecao(_canditato, 1);
            _candidatosParaSelecao = new List<CandidatoParaSelecao> {_candidatoParaSelecao};
        }


        [Test]
        public void DeveBuscarCandidatoContratadoParaSetarComoContratado()
        {
            _servicoParaContratarCandidato.MarcarCandidatoComoContratado(_canditato);
            
            _candidatoParaSelecaoRepositorio.Verify(x => x.ObterPor(_canditato),Times.Once());
        }

        [Test]
        public void DeveMarcarComoContratadoTodosOsCandidato()
        {
            _candidatoParaSelecaoRepositorio.Setup(x => x.ObterPor(_canditato)).Returns(_candidatosParaSelecao);
            
            _servicoParaContratarCandidato.MarcarCandidatoComoContratado(_canditato);

            Assert.AreEqual(_candidatoParaSelecao.Status, StatusDoCandidatoNoProcesso.Contratado);
        }
    }
}
