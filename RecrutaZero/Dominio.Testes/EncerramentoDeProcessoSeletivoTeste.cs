using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RecrutaZero.Dominio.EnvioDeEmail;
using RecrutaZero.Dominio.Testes.Builders;

namespace RecrutaZero.Dominio.Testes
{
    [TestFixture]
    public class EncerramentoDeProcessoSeletivoTeste
    {
        private ProcessoSeletivo _processoSeletivo;
        private Mock<IEnvioDeEmail> _envioDeEmail;
        private EncerramentoDeProcessoSeletivo _encerramentoDeProcessoSeletivo;
        private List<CandidatoParaSelecao> _candidatosParaSelecao;
        private CandidatoParaSelecao _candidatoReprovado;
        private CandidatoParaSelecao _candidatoContratado;
        private CandidatoParaSelecao _candidatoReprovado2;
        private DateTime _dataDeEncerramento;

        [SetUp]
        public void SetUp()
        {
            _envioDeEmail = new Mock<IEnvioDeEmail>();
            _candidatoReprovado = CandidatoParaSelecaoBuilder.UmCandidatoParaSelecao().ComStatus(StatusDoCandidatoNoProcesso.Pendente).Build();
            _candidatoReprovado2 = CandidatoParaSelecaoBuilder.UmCandidatoParaSelecao().ComStatus(StatusDoCandidatoNoProcesso.Pendente).Build();
            _candidatoContratado = CandidatoParaSelecaoBuilder.UmCandidatoParaSelecao().ComStatus(StatusDoCandidatoNoProcesso.Contratado).Build();
            _candidatosParaSelecao = new List<CandidatoParaSelecao> { _candidatoContratado, _candidatoReprovado, _candidatoReprovado2 };
            _encerramentoDeProcessoSeletivo = new EncerramentoDeProcessoSeletivo(_envioDeEmail.Object);
            _processoSeletivo = ProcessoSeletivoBuilder.UmProcessoSeletivo().Build();
            _dataDeEncerramento = DateTime.Today;
        }


        [Test]
        public void DeveEncerrarProcessoSeletivo()
        {
            _processoSeletivo.Abrir(_candidatosParaSelecao);
            _encerramentoDeProcessoSeletivo.Encerrar(_processoSeletivo, _dataDeEncerramento);

            Assert.AreEqual(_processoSeletivo.Status, StatusDoProcessoSeletivo.Finalizado);
        }

        [Test]
        public void DeveEnviarEmailParaTodosQueNaoForamContratados()
        {
            _processoSeletivo.Abrir(_candidatosParaSelecao);
            _encerramentoDeProcessoSeletivo.Encerrar(_processoSeletivo, _dataDeEncerramento);

            _envioDeEmail.Verify(x => x.EnviarEmailDuMau(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
