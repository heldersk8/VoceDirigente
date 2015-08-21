using System;
using System.Linq.Expressions;

namespace Dominio.Specifications
{
    public sealed class DirectSpecification<TEntidade> : Specification<TEntidade> where TEntidade : class
    {
        readonly Expression<Func<TEntidade, bool>> _matchingCriteria;

        public DirectSpecification(Expression<Func<TEntidade, bool>> matchingCriteria)
        {
            if (matchingCriteria == null)
                throw new ArgumentNullException("matchingCriteria");

            _matchingCriteria = matchingCriteria;
        }

        public override Expression<Func<TEntidade, bool>> SatisfiedBy()
        {
            return _matchingCriteria;
        }
    }
}
