using NHibernate;
using NHibernate.Context;

namespace RecrutaZero.Infra._Base.Configuracoes
{
    public class Contexto
    {
        public static ISessionFactory SessionFactory { get; internal set; }
        public static ISession Sessao { get { return SessionFactory.GetCurrentSession(); } }

        public static void LigarContextoDaSessaoNh()
        {
            var sessao = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(sessao);
        }

        public static void DesligarContextoDaSessaoNh()
        {
            var sessao = Sessao;
            CurrentSessionContext.Unbind(SessionFactory);
            if (sessao != null)
                sessao.Dispose();
        }
    }
}
