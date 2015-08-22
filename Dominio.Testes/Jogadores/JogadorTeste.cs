using System.Linq;
using Dominio.Doacoes;
using Dominio.Jogadores;
using Nosbor.FluentBuilder.Lib;
using NUnit.Framework;

namespace RecrutaZero.Dominio.Testes.Jogadores
{
    [TestFixture]
    public class JogadorTeste
    {
        [Test]
        public void DeveEfetuarUmaDoacaoParaOJogador()
        {
            var doacao = FluentBuilder<Doacao>.New().Build();
            var jogador = FluentBuilder<Jogador>.New().Build();

            jogador.Efetuar(doacao);

            Assert.IsTrue(jogador.Doacoes.Any(doa => doa == doacao));
        }
    }
}
