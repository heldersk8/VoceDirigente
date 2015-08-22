using Dominio.Doacoes;
using Dominio.Excecao;
using Nosbor.FluentBuilder.Lib;
using NUnit.Framework;

namespace RecrutaZero.Dominio.Testes.Doacoes
{
    [TestFixture]
    public class DoacaoTeste
    {
        [Test]
        public void NaoDevePermitirDoacaoNegativa()
        {
            var doador = FluentBuilder<Doador>.New().Build();

            Assert.Throws<ExcecaoDeDominio<Doacao>>(() => new Doacao(doador,-1));
        }
    }
}
