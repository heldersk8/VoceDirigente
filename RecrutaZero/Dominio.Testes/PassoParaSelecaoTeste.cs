using System;
using NUnit.Framework;
using RecrutaZero.Dominio.Excecao;

namespace RecrutaZero.Dominio.Testes
{
    [TestFixture]
    public class PassoParaSelecaoTeste
    {
        [Test]
        public void NaoDeveCriarSemPasso()
        {
            Assert.Throws<ExcecaoDeDominio<PassoParaSelecao>>(() => new PassoParaSelecao(null));
        }

        [Test]
        public void DeveCriarComoPendente()
        {
            var passoParaSelecao = new PassoParaSelecao(new Mbti());

            Assert.AreEqual(StatusDoPassoParaSelecao.Pendente, passoParaSelecao.Status);
        }

        [Test]
        public void DeveAtribuirObs()
        {
            const string obs = "Oi";
            var passoParaSelecao = new PassoParaSelecao(new Mbti());

            passoParaSelecao.AtribuirObservacao(obs);

            Assert.AreEqual(obs, passoParaSelecao.Observacao);
        }

        [Test]
        public void DeveAtribuirData()
        {
            var data = DateTime.Now;
            var passoParaSelecao = new PassoParaSelecao(new Mbti());

            passoParaSelecao.AtribuirData(data);

            Assert.AreEqual(data, passoParaSelecao.Data);
        }

        [Test]
        public void DeveMarcarSeEstaApto()
        {
            var passoParaSelecao = new PassoParaSelecao(new Mbti());

            passoParaSelecao.AtribuirStatus(true);
            Assert.AreEqual(StatusDoPassoParaSelecao.Apto, passoParaSelecao.Status);

            passoParaSelecao.AtribuirStatus(false);
            Assert.AreEqual(StatusDoPassoParaSelecao.Inapto, passoParaSelecao.Status);
        }
    }
}