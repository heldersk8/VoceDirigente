using System;
using System.Linq.Expressions;

namespace RecrutaZero.Dominio.Testes.Helpers.Extensions
{
    public static class ExtensoesDeTiposGenericos
    {
        public static void Setar<T, TW>(this T tipo, Expression<Func<TW>> propriedade, TW novoValor)
        {
            var memberExpression = propriedade.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("Expression deve ser do tipo MemberExpression", "propriedade");

            var nomeDaPropriedade = memberExpression.Member.Name;

            typeof(T).GetProperty(nomeDaPropriedade).SetValue(tipo, novoValor, null);
        }
    }
}