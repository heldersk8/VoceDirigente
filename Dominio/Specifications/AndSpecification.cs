using System;
using System.Linq.Expressions;

namespace Dominio.Specifications
{
    public sealed class AndSpecification<T> : CompositeSpecification<T> where T : class
    {
        private readonly ISpecification<T> _rightSideSpecification = null;
        private readonly ISpecification<T> _leftSideSpecification = null;

        public AndSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            if (leftSide == null)
                throw new ArgumentNullException("leftSide");

            if (rightSide == null)
                throw new ArgumentNullException("rightSide");

            _leftSideSpecification = leftSide;
            _rightSideSpecification = rightSide;
        }

        public override ISpecification<T> LeftSideSpecification
        {
            get { return _leftSideSpecification; }
        }

        public override ISpecification<T> RightSideSpecification
        {
            get { return _rightSideSpecification; }
        }

        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            var left = _leftSideSpecification.SatisfiedBy();
            var right = _rightSideSpecification.SatisfiedBy();

            return (left.And(right));
        }
    }
}
