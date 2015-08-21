using System;
using System.Linq;
using NUnit.Framework;
using RecrutaZero.Dominio.Testes.Builders;

namespace RecrutaZero.Dominio.Testes
{
    [TestFixture]
    public class ClassificarAptidaoTeste
    {
        [Test]
        public void DeveSalvarOsDadosDeUmaAptidao()
        {
            const string observacao = "Obs";
            var data = DateTime.Now;
            var candidatoParaSelecao = new CandidatoParaSelecao(CandidatoBuilder.UmCandidato().Build(), 1);
            var passo = new Mbti();

            (new ClassificarAptidao()).Salvar(candidatoParaSelecao, passo, observacao, data, true);

            var aptidaoParaSelecao = candidatoParaSelecao.Aptidoes.FirstOrDefault(x => x.Passo == passo);

            Assert.AreEqual(observacao, aptidaoParaSelecao.Observacao);
            Assert.AreEqual(data, aptidaoParaSelecao.Data.Value);
            Assert.AreEqual(StatusDoPassoParaSelecao.Apto, aptidaoParaSelecao.Status);
        }
    }
}