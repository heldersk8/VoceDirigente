using Dominio.Jogadores;
using System.Collections.Generic;

namespace Dominio.Repositorios
{
    public interface IJogadorRepositorio : IRepositorioBase<Jogador>
    {
        IEnumerable<Jogador> ObterPorPosicao(int posicao);
    }
}
