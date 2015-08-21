using System.ComponentModel;

namespace Dominio.Jogadores
{
    public enum Clubes
    {
        Cruzeiro = 1,
        Corinthians = 2,
        Flamengo = 3,
        [Description("Grêmio")]
        Gremio = 4,
        Santos = 5,
        [Description("Atlético")]
        Atletico = 6,
        [Description("São Paulo")]
        SaoPaulo = 7,
        Internacional = 8,
        Vasco = 9,
        Palmeiras = 10,
        PSG = 11,
        [Description("Málaga")]
        Malaga = 12,
        Figueirense = 13,
        Botafogo = 14,
    }
}