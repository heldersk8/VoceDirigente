using System;
using RecrutaZero.Dominio.Comum;
using RecrutaZero.Dominio.Validacao;

namespace RecrutaZero.Dominio
{
    public class PassoParaSelecao : Entidade<PassoParaSelecao>
    {
        public virtual Passo Passo { get; protected set; }
        public virtual string Observacao { get; protected set; }
        public virtual DateTime? Data { get; protected set; }
        public virtual StatusDoPassoParaSelecao Status { get; protected set; }

        protected PassoParaSelecao() { }

        public PassoParaSelecao(Passo passo)
        {
            Validacao<PassoParaSelecao>.EhObrigatorio(passo, "Passo deve ser informado");

            Passo = passo;
            Status = StatusDoPassoParaSelecao.Pendente;
        }

        public virtual void AtribuirObservacao(string observacao)
        {
            Observacao = observacao;
        }

        public virtual void AtribuirData(DateTime data)
        {
            Data = data;
        }

        public virtual void AtribuirStatus(bool estaApto)
        {
            Status = estaApto ? StatusDoPassoParaSelecao.Apto : StatusDoPassoParaSelecao.Inapto;
        }
    }
}