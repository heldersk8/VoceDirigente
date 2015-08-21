using Dominio.Comum;
using Dominio.Jogadores;

namespace Dominio.Doacoes
{
    public class Doacao : Entidade<Doacao>
    {
        public Jogador Jogador { get; set; }
        public Doador Doador { get; set; }
        public decimal Valor { get; set; }

        public Doacao(Jogador jogador, Doador doador, decimal valor)
        {
            Jogador = jogador;
            Doador = doador;
            Valor = valor;
        }
    }
}