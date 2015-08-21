using System;
using System.Web.Mvc;
using Infra._Base.Configuracoes;

namespace ODirigente.Infra
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!PossuiSessaoNoContexto()) return;
            Contexto.Sessao.BeginTransaction();
        }

        private static bool PossuiSessaoNoContexto()
        {
            return Contexto.Sessao != null;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (!PossuiSessaoNoContexto()) return;

            var transacao = Contexto.Sessao.Transaction;

            if (transacao == null || !transacao.IsActive) return;

            if (filterContext.Exception == null)
                transacao.Commit();
        }
    }
}