using Dominio.Comum;

namespace Dominio.Doacoes
{
    public class Doador : Entidade<Doador>
    {
        public string Nome { get; set; }
        public string CartaoDeCredito { get; set; }

        public Doador(string nome, string cartaoDeCredito)
        {
            Nome = nome;
            CartaoDeCredito = cartaoDeCredito;
        }
    }
}