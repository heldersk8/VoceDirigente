using System.Collections.Generic;
using RecrutaZero.Dominio.Comum;
using RecrutaZero.Dominio.Specifications;

namespace RecrutaZero.Dominio.Repositorios
{
    public interface IRepositorioBase<T> where T : Entidade<T>
    {
        T ObterPor(int id);
        IEnumerable<T> ObterPor(ISpecification<T> specification);
        IEnumerable<T> ObterTodos();
        void Adicionar(T entidade);
    }
}