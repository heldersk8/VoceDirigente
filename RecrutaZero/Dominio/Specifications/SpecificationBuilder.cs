using System;
using System.Linq.Expressions;

namespace RecrutaZero.Dominio.Specifications
{
    public class SpecificationBuilder<T> where T : class
    {
        private Specification<T> _spec = new DirectSpecification<T>(x => true);

        public static SpecificationBuilder<T> UmaSpec()
        {
            return new SpecificationBuilder<T>();
        }

        public SpecificationBuilder<T> Atendendo(Expression<Func<T, bool>> satisfeitaPor)
        {
            _spec &= new DirectSpecification<T>(satisfeitaPor);
            return this;
        }

        public SpecificationBuilder<T> Quando(bool condicao, Expression<Func<T, bool>> satisfeitaPor)
        {
            if (condicao) _spec &= new DirectSpecification<T>(satisfeitaPor);
            return this;
        }

        public Specification<T> Build()
        {
            return _spec;
        }
    }
}