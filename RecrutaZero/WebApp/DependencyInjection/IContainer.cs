using System;
using System.Collections.Generic;

namespace RecrutaZero.WebApp.DependencyInjection
{
    public interface IContainer
    {
        object Get(Type type);
        void BuildUp(object obj);
        object Get<T>();
        IEnumerable<T> GetAll<T>();
        void Release(object instance);
    }
}