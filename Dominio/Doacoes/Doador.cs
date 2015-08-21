using Dominio.Comum;

namespace Dominio.Doacoes
{
    public class Doador : Entidade<Doador>
    {
        public virtual string Nome { get; set; }
        public virtual string CartaoDeCredito { get; set; }

        protected Doador() { }

        public Doador(string nome, string cartaoDeCredito)
        {
            Nome = nome;
            CartaoDeCredito = cartaoDeCredito;
        }
    }
}