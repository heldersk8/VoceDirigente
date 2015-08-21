using System.Collections.Generic;
using Dominio.Jogadores;

namespace Dominio.Repositorios
{
    public interface IJogadorRepositorio : IRepositorioBase<Jogador>
    {
        IEnumerable<Jogador> ObterTodosZagueiros();
    }
}
