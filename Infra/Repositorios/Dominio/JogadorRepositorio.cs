using Dominio.Jogadores;
using Dominio.Repositorios;
using Infra._Base.Repositorios;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositorios.Dominio
{
    public class JogadorRepositorio : RepositorioBaseDominio<Jogador>, IJogadorRepositorio
    {
        public JogadorRepositorio(ISession sessao) : base(sessao) { }

        public IEnumerable<Jogador> ObterPorPosicao(int posicao)
        {
            return Entidades().Where(jogador => jogador.Posicao == (Posicao)posicao);
        }

    }
}
