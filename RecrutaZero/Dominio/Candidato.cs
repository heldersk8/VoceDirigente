using System;
using RecrutaZero.Dominio.Validacao;
using RecrutaZero.Dominio.Comum;

namespace RecrutaZero.Dominio
{
    public class Candidato : Entidade<Candidato>
    {
        public virtual string Nome { get; protected set; }
        public virtual Ocupacao Ocupacao { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Origem { get; protected set; }
        public virtual string Telefone { get; protected set; }
        public virtual string Twitter { get; protected set; }
        public virtual string Facebook { get; protected set; }
        public virtual string Linkedin { get; protected set; }
        public virtual string SitePessoal { get; protected set; }
        public virtual StatusDoCandidato Status { get; set; }
        public virtual DateTime? DataDeContratacao { get; set; }

        protected Candidato() { }

        public Candidato(string nome, Ocupacao ocupacao, string email, string origem, string telefone)
        {
            Validacao<Candidato>.EhObrigatorio(nome, "Não é possível criar candidato sem nome");
            Validacao<Candidato>.EhObrigatorio(email, "Não é possível criar candidato sem email");
            Validacao<Candidato>.EhObrigatorio(telefone, "Não é possível criar candidato sem telefone");
            Validacao<Candidato>.EhObrigatorio(origem, "Não é possível criar candidato sem origem");

            Nome = nome;
            Ocupacao = ocupacao;
            Email = email;
            Origem = origem;
            Telefone = telefone;
        }

        public virtual void AdicionarInformacoesAdicionais(string twitter, string facebook, string linkedin, string sitePessoal)
        {
            Twitter = twitter;
            Facebook = facebook;
            Linkedin = linkedin;
            SitePessoal = sitePessoal;
        }

        public virtual void Contratar(DateTime dataDeContratacao)
        {
            Status = StatusDoCandidato.Contratado;
            DataDeContratacao = dataDeContratacao;
        }
    }
}