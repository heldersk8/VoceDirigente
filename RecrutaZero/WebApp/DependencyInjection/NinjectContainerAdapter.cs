using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Modules;

namespace RecrutaZero.WebApp.DependencyInjection
{
    public class NinjectContainerAdapter : IContainer
    {
        protected StandardKernel Container { get; set; }

        public NinjectContainerAdapter(INinjectModule configuracaoDeDI)
        {
            Container = new StandardKernel(configuracaoDeDI);
        }

        public object Get(Type type)
        {
            return Container.Get(type);
        }

        public object Get<T>()
        {
            return Container.Get<T>();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return Container.GetAll<T>();
        }

        public void Release(object instance)
        {
            Container.Release(instance);
        }

        public void BuildUp(Object objeto)
        {
            Container.Inject(objeto);
        }
    }
}