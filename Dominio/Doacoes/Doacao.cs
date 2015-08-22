using Dominio.Comum;
using Dominio.Validacao;

namespace Dominio.Doacoes
{
    public class Doacao : Entidade<Doacao>
    {
        public virtual Doador Doador { get; set; }
        public virtual decimal Valor { get; set; }

        protected Doacao() { }  

        public Doacao(Doador doador, decimal valor)
        {
            Validar(valor);
            Doador = doador;
            Valor = valor;
        }

        private void Validar(decimal valor)
        {
            Validacao<Doacao>.Quando(valor < 0, "Valor inválido");
        }
    }
}