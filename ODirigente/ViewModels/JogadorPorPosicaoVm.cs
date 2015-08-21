using Dominio.Jogadores;
using System.Collections.Generic;

namespace ODirigente.ViewModels
{
    public class JogadorPorPosicaoVm
    {
        public IEnumerable<Jogador> Jogadores { get; set; }
    }
}