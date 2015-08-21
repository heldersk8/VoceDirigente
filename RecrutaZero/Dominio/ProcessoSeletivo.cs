using System;
using System.Collections.Generic;
using System.Linq;
using RecrutaZero.Dominio.Comum;
using RecrutaZero.Dominio.Validacao;

namespace RecrutaZero.Dominio
{
    public class ProcessoSeletivo : Entidade<ProcessoSeletivo>
    {
        public virtual Ocupacao Ocupacao { get; protected set; }
        public virtual string ParaOTime { get; protected set; }
        public virtual string DescricaoDaVaga { get; protected set; }
        public virtual StatusDoProcessoSeletivo Status { get; protected set; }
        public virtual DateTime DataDeInicio { get; set; }
        public virtual DateTime DataDeEncerramento { get; set; }

        private IList<CandidatoParaSelecao> _candidatos = new List<CandidatoParaSelecao>();
        public virtual IEnumerable<CandidatoParaSelecao> Candidatos { get { return _candidatos; } }


        protected ProcessoSeletivo() { }

        public ProcessoSeletivo(Ocupacao ocupacao, string paraOTime, string descricaoDaVaga)
        {
            Validacao<ProcessoSeletivo>.EhObrigatorio(ocupacao, "N�o � poss�vel criar processo seletivo sem a ocupa��o");
            Validacao<ProcessoSeletivo>.EhObrigatorio(paraOTime, "N�o � poss�vel criar processo seletivo sem o Time para qual a pessoa est� sendo selecionada");
            Validacao<ProcessoSeletivo>.EhObrigatorio(descricaoDaVaga, "N�o � poss�vel criar processo seletivo sem a descri��o da vaga");

            Ocupacao = ocupacao;
            ParaOTime = paraOTime;
            DescricaoDaVaga = descricaoDaVaga;
        }

        public virtual void Abrir(IEnumerable<CandidatoParaSelecao> candidatosParaSelecao)
        {
            _candidatos = candidatosParaSelecao.ToList();

            Status = StatusDoProcessoSeletivo.EmAndamento;
            DataDeInicio = DateTime.Today;
        }

        public virtual void Contratar(CandidatoParaSelecao candidatoParaSelecao, DateTime dataDeContratacao)
        {
            candidatoParaSelecao.Contratado(dataDeContratacao);
        }

        public virtual void Encerrar(DateTime dataDeEncerramento)
        {
            Validacao<ProcessoSeletivo>.Quando(Status != StatusDoProcessoSeletivo.EmAndamento, "N�o � poss�vel encerrar esse processo seletivo");
            Validacao<ProcessoSeletivo>.Quando(dataDeEncerramento > DateTime.Now, "N�o � poss�vel encerrar processo seletivo com data futura");

            Status = StatusDoProcessoSeletivo.Finalizado;
            DataDeEncerramento = dataDeEncerramento;
        }
    }
}