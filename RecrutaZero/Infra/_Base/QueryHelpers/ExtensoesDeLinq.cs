using System;
using System.Linq;
using System.Linq.Expressions;

namespace RecrutaZero.Infra._Base.QueryHelpers
{
    public static class ExtensoesDeLinq
    {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            return (condition) ? source.Where(predicate) : source;
        }
    }
}