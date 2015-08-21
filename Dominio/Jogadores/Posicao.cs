using System.ComponentModel;

namespace Dominio.Jogadores
{
    public enum Posicao
    {
        Goleiro = 1,
        Zagueiro = 2,
        [Description("Lateral Direito")]
        LateralDireito = 3,
        [Description("Lateral Esquerdo")]
        LateralEsquerdo = 4,
        Meia = 5,
        Atacante = 6
    }
}