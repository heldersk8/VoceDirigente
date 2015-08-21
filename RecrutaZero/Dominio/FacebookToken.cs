using RecrutaZero.Dominio.Comum;

namespace RecrutaZero.Dominio
{
    public class FacebookToken : Entidade<FacebookToken>
    {
        public virtual string Token { get; protected set; }

        protected FacebookToken() { }

        public virtual void Atualizar(string novoToken)
        {
            Token = novoToken;
        }
    }
}