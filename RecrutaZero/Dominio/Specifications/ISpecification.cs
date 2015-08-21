using System;
using System.Linq.Expressions;

namespace RecrutaZero.Dominio.Specifications
{
    public interface ISpecification<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
