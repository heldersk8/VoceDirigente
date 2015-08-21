using System;
using System.Linq;
using System.Reflection;
using Dominio.Repositorios;
using Infra.DI;
using Infra._Base.Configuracoes;
using NHibernate;
using Ninject.Components;
using Ninject.Modules;
using Ninject.Selection.Heuristics;

namespace ODirigente.Infra
{
    public class NinjectWebAppModule : NinjectModule
    {
        public class CustomInjectionHeuristic : NinjectComponent, IInjectionHeuristic
        {
            public bool ShouldInject(MemberInfo member)
            {
                return member.IsDefined(typeof(PropertyInjection), true);
            }
        }

        public override void Load()
        {
            RegistrarTodosOsAssemblies();
            SpecificBindings();
        }

        protected virtual void RegistrarTodosOsAssemblies()
        {
            RegistrarAssembly(typeof(Configurador));
            RegistrarAssembly(typeof(MvcApplication));
            RegistrarAssembly(typeof(IJogadorRepositorio));
        }

        protected virtual void SpecificBindings()
        {
            Kernel.Bind<ISession>().ToMethod(x => Contexto.Sessao);
        }


        protected virtual void RegistrarAssembly(Type type)
        {
            var assembly = Assembly.GetAssembly(type);

            var classes = from t in assembly.GetTypes()
                          where t.IsPublic && !t.IsAbstract && t.IsClass
                          select t;

            foreach (var @class in classes)
            {
                foreach (var @interface in @class.GetInterfaces())
                    Kernel.Bind(@interface).To(@class);

                if (@class.BaseType != null && @class.BaseType.IsAbstract)
                    Kernel.Bind(@class.BaseType).To(@class);
            }
        }
    }

}