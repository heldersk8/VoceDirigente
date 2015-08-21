using System;
using System.Collections.Generic;
using System.Linq;
using RecrutaZero.Dominio.Comum;

namespace RecrutaZero.Dominio
{
    public class CandidatoParaSelecao : Entidade<CandidatoParaSelecao>
    {
        public virtual Ocupacao Ocupacao { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Origem { get; protected set; }
        public virtual string Telefone { get; protected set; }
        public virtual string Twitter { get; protected set; }
        public virtual string Facebook { get; protected set; }
        public virtual string Linkedin { get; protected set; }
        public virtual string SitePessoal { get; protected set; }
        public virtual Candidato Candidato { get; protected set; }
        public virtual int IdProcessoSeletivo { get; protected set; }
        public virtual StatusDoCandidatoNoProcesso Status { get; set; }

        private IList<PassoParaSelecao> _aptidoes = new List<PassoParaSelecao>();
        public virtual IEnumerable<PassoParaSelecao> Aptidoes { get { return _aptidoes; } }

        protected CandidatoParaSelecao() { }

        public CandidatoParaSelecao(Candidato candidato, int idProcessoSeletivo)
        {
            Ocupacao = candidato.Ocupacao;
            Nome = candidato.Nome;
            Email = candidato.Email;
            Origem = candidato.Origem;
            Telefone = candidato.Telefone;
            Twitter = candidato.Twitter;
            Facebook = candidato.Facebook;
            Linkedin = candidato.Linkedin;
            SitePessoal = candidato.SitePessoal;
            Candidato = candidato;
            IdProcessoSeletivo = idProcessoSeletivo;

            CriarPassos();
        }

        private void CriarPassos()
        {
            _aptidoes = TodosOsPassos.ListarTodos.Select(x => new PassoParaSelecao(x)).ToList();
        }

        public virtual void Contratado(DateTime dataDeContratacao)
        {
            Status = StatusDoCandidatoNoProcesso.Contratado;
            Candidato.Contratar(dataDeContratacao);
        }

        public virtual void MarcarComoContratadoParaOProcessoDeSelecao()
        {
            Status = StatusDoCandidatoNoProcesso.Contratado;
        }
    }
}