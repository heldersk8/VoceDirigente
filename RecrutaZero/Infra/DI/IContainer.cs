using System;
using System.Collections.Generic;

namespace RecrutaZero.Infra.DI
{
    public interface IContainer
    {
        object Get(Type type);
        void BuildUp(object obj);
        object Get<T>();
        IEnumerable<T> GetAll<T>();
    }
}