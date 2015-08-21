using System.Linq;
using System.Reflection;
using System.Web;
using NHibernate;
using Ninject.Components;
using Ninject.Modules;
using Ninject.Selection.Heuristics;
using RecrutaZero.Infra._Base.Configuracoes;

namespace RecrutaZero.WebApp.DependencyInjection
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
            RegistrarComponentesCustomizados();
            RegistrarTodosOsAssemblies();
            RegistrarBindingsEspecificos();
        }

        private void RegistrarComponentesCustomizados()
        {
            Kernel.Components.Add<IInjectionHeuristic, CustomInjectionHeuristic>();
        }

        private void RegistrarTodosOsAssemblies()
        {
            RegistrarAssembly("RecrutaZero.WebApp");
            RegistrarAssembly("RecrutaZero.Infra");
            RegistrarAssembly("RecrutaZero.Dominio");
        }

        private void RegistrarBindingsEspecificos()
        {
            Kernel.Bind<ISession>().ToMethod(x => Contexto.Sessao);
            Kernel.Bind<HttpContextBase>().ToMethod(x => new HttpContextWrapper(HttpContext.Current));

            Kernel.Components.Add<IInjectionHeuristic, CustomInjectionHeuristic>();
        }

        private void RegistrarAssembly(string assemblyFullName)
        {
            var assembly = Assembly.Load(assemblyFullName);
            RegistrarAssembly(assembly);
        }

        private void RegistrarAssembly(Assembly assembly)
        {
            var classes = assembly.GetTypes().Where(t => t.IsPublic && !t.IsAbstract && t.IsClass);

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
