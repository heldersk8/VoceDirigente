using Dominio.Comum;
using Dominio.Jogadores;

namespace Dominio.Doacoes
{
    public class Doacao : Entidade<Doacao>
    {
        public virtual Jogador Jogador { get; set; }
        public virtual Doador Doador { get; set; }
        public virtual decimal Valor { get; set; }

        protected Doacao()
        { }

        public Doacao(Jogador jogador, Doador doador, decimal valor)
        {
            Jogador = jogador;
            Doador = doador;
            Valor = valor;
        }
    }
}