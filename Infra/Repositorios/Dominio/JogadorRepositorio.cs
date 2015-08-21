using System.Collections.Generic;
using System.Linq;
using Dominio.Jogadores;
using Dominio.Repositorios;
using Infra._Base.Repositorios;
using NHibernate;

namespace Infra.Repositorios.Dominio
{
    public class JogadorRepositorio : RepositorioBaseDominio<Jogador>, IJogadorRepositorio
    {
        public JogadorRepositorio(ISession sessao) : base(sessao) { }

        public IEnumerable<Jogador> ObterTodosZagueiros()
        {
            return Entidades().Where(jogador => jogador.Posicao == Posicao.Zagueiro);
        }

    }
}
