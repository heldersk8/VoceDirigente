using System;
using System.Linq;
using NUnit.Framework;
using RecrutaZero.Dominio.Testes.Builders;

namespace RecrutaZero.Dominio.Testes
{
    [TestFixture]
    public class CandidatoParaSelecaoTeste
    {
        private Candidato _candidato;
        private ProcessoSeletivo _processoSeletivo;
        private int _idProcessoSeletivo;
        private CandidatoParaSelecao _candidatoParaSelecao;

        [SetUp]
        public void SetUp()
        {
            _candidato = CandidatoBuilder.UmCandidato().ComNome("José").ComEmail("a@a.com").ComOrigem("Indicação").ComTelefone("99999999")
                .ComTwitter("@rawr").ComFacebook("facebook.com/x").ComLinkedIn("linkedin.com/x").ComSitePessoal("github.com/x").Build();
            _idProcessoSeletivo = 1;
            _candidatoParaSelecao = new CandidatoParaSelecao(_candidato, _idProcessoSeletivo);
        }

        [Test]
        public void DeveCriarCandidatoParaSelecao()
        {
            Assert.AreEqual(_candidatoParaSelecao.Nome, _candidato.Nome);
            Assert.AreEqual(_candidatoParaSelecao.Ocupacao, _candidato.Ocupacao);
            Assert.AreEqual(_candidatoParaSelecao.Email, _candidato.Email);
            Assert.AreEqual(_candidatoParaSelecao.Origem, _candidato.Origem);
            Assert.AreEqual(_candidatoParaSelecao.Telefone, _candidato.Telefone);
            Assert.AreEqual(_candidatoParaSelecao.Twitter, _candidato.Twitter);
            Assert.AreEqual(_candidatoParaSelecao.Facebook, _candidato.Facebook);
            Assert.AreEqual(_candidatoParaSelecao.Linkedin, _candidato.Linkedin);
            Assert.AreEqual(_candidatoParaSelecao.SitePessoal, _candidato.SitePessoal);
        }

        [Test]
        public void DeveCriarCandidatoParaSelecaoComProcessoSeletivo()
        {
            Assert.AreEqual(_candidatoParaSelecao.IdProcessoSeletivo, _idProcessoSeletivo);
        }

        [Test]
        public void DeveMarcarCandidatoParaSelecaoComoContratado()
        {
            _candidatoParaSelecao.Contratado(DateTime.Today);

            Assert.AreEqual(_candidatoParaSelecao.Status, StatusDoCandidatoNoProcesso.Contratado);
        }

        [Test]
        public void DeveCriarComTodasAsAptidoes()
        {
            var aptidoesEsperadas = TodosOsPassos.ListarTodos.Select(x => new PassoParaSelecao(x));

            CollectionAssert.AreEqual(aptidoesEsperadas.Select(x => x.Passo), _candidatoParaSelecao.Aptidoes.Select(x => x.Passo));
        }
    }
}
