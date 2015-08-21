using System.Linq.Expressions;

namespace RecrutaZero.Dominio.Excecao
{
    public class ViolacaoDeRegra
    {
        public LambdaExpression Propriedade { get; internal set; }
        public string Mensagem { get; internal set; }
    }
}
