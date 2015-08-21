using Dominio.Comum;
using Dominio.Specifications;
using System.Collections.Generic;

namespace Dominio.Repositorios
{
    public interface IRepositorioBase<T> where T : Entidade<T>
    {
        T ObterPor(int id);
        IEnumerable<T> ObterPor(ISpecification<T> specification);
        IEnumerable<T> ObterTodos();
        void Adicionar(T entidade);
    }
}