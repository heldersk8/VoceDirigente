using Dominio.Comum;

namespace Dominio.Doacoes
{
    public class Doacao : Entidade<Doacao>
    {
        public virtual Doador Doador { get; set; }
        public virtual decimal Valor { get; set; }

        protected Doacao() { }  

        public Doacao(Doador doador, decimal valor)
        {
            Doador = doador;
            Valor = valor;
        }
    }
}