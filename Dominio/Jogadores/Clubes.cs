using System.ComponentModel;

namespace Dominio.Jogadores
{
    public enum Clubes
    {
        Cruzeiro = 1,
        Corinthians = 2,
        Flamengo = 3,
        [Description("Gr�mio")]
        Gremio = 4,
        Santos = 5,
        [Description("Atl�tico")]
        Atletico = 6,
        [Description("S�o Paulo")]
        SaoPaulo = 7,
        Internacional = 8,
        Vasco = 9,
        Palmeiras = 10,
        PSG = 11,
        [Description("M�laga")]
        Malaga = 12,
        Figueirense = 13,
        Botafogo = 14,
    }
}