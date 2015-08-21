using System.Diagnostics;
using NUnit.Framework;
using RecrutaZero.Dominio.Excecao;
using RecrutaZero.Dominio.Testes.Helpers;

namespace RecrutaZero.Dominio.Testes
{
    [TestFixture]
    public class CandidatoTeste
    {
        private string _nome;
        private Ocupacao _ocupacao;
        private string _telefone;
        private string _email;
        private string _origem;
        private string _twitter;
        private string _facebook;
        private string _linkedin;
        private string _sitePessoal;

        [SetUp]
        public void SetUp()
        {
            _nome = "nome";
            _ocupacao = new Ocupacao("Desenvolvedor");
            _telefone = "99999999";
            _email = "aw@aw.com";
            _origem = "indicação";
            _twitter = "@twitter";
            _facebook = "facebook.com/facebook";
            _linkedin = "linkedin.com/joao";
            _sitePessoal = "github.com/joao";

        }

        [Test]
        public void DeveCriarCandidatoComCampoObrigatorios()
        {
            var candidato = new Candidato(_nome, _ocupacao, _email, _origem, _telefone);

            Assert.AreEqual(candidato.Nome, _nome);
            Assert.AreEqual(candidato.Ocupacao, _ocupacao);
            Assert.AreEqual(candidato.Email, _email);
            Assert.AreEqual(candidato.Origem, _origem);
            Assert.AreEqual(candidato.Telefone, _telefone);
        }

        [Test]
        public void DeveAdicionarInformacoesAdicionais()
        {
            var candidato = new Candidato(_nome, _ocupacao, _email, _origem, _telefone);

            candidato.AdicionarInformacoesAdicionais(_twitter,_facebook,_linkedin,_sitePessoal);

            Assert.AreEqual(candidato.Twitter, _twitter);
            Assert.AreEqual(candidato.Facebook, _facebook);
            Assert.AreEqual(candidato.Linkedin, _linkedin);
            Assert.AreEqual(candidato.SitePessoal, _sitePessoal);
        }

        [Test]
        public void NaoDeveCriarCandidatoSemNome()
        {
            Assert.Throws<ExcecaoDeDominio<Candidato>>(() => new Candidato("", _ocupacao, "", "", "")).ComMensagem("Não é possível criar candidato sem nome");
        }

        [Test]
        public void NaoDeveCriarCandidatoSemOcupacao()
        {
            Assert.Throws<ExcecaoDeDominio<Candidato>>(() => new Candidato("", null, "", "", "")).ComMensagem("Não é possível criar candidato sem nome");
        }

        [Test]
        public void NaoDeveCriarCandidatoSemEmail()
        {
            Assert.Throws<ExcecaoDeDominio<Candidato>>(() => new Candidato(_nome, _ocupacao, "", _origem, _telefone)).ComMensagem("Não é possível criar candidato sem email");
        }

        [Test]
        public void NaoDeveCriarCandidatoSemTelefone()
        {
            Assert.Throws<ExcecaoDeDominio<Candidato>>(() => new Candidato(_nome, _ocupacao, _email, _origem, "")).ComMensagem("Não é possível criar candidato sem telefone");
        }

        [Test]
        public void NaoDeveCriarCandidatoSemOrigem()
        {
            Assert.Throws<ExcecaoDeDominio<Candidato>>(() => new Candidato(_nome, _ocupacao, _email, "", _telefone)).ComMensagem("Não é possível criar candidato sem origem");
        }
    }
}
