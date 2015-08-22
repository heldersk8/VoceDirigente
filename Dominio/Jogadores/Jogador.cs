using Dominio.Comum;
using Dominio.Doacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Jogadores
{
    public class Jogador : Entidade<Jogador>
    {
        private List<Doacao> _doacoes;

        public virtual string Apelido { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DataDeNascimento { get; set; }
        public virtual Posicao Posicao { get; set; }
        public virtual int NumeroDeGols { get; set; }
        public virtual int Assistencias { get; set; }
        public virtual int Desarmes { get; set; }
        public virtual int Altura { get; set; }
        public virtual bool EhCanhoto { get; set; }
        public virtual decimal ValorDoPasse { get; set; }
        public virtual int Likes { get; set; }
        public virtual int Dislikes { get; set; }
        public virtual decimal TotalDeDoacoes { get { return Doacoes.Sum(x => x.Valor); } }
        public virtual IEnumerable<Doacao> Doacoes { get { return _doacoes; } }

        public virtual int PorcentagemBarraDeProgresso
        {
            get { return (int)((TotalDeDoacoes/ValorDoPasse)*100); }
        }

        protected Jogador() { }

        public Jogador(string apelido, string nome, DateTime dataDeNascimento, Posicao posicao, int numeroDeGols, int assistencias, int desarmes, int altura, bool ehCanhoto)
        {
            Apelido = apelido;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Posicao = posicao;
            NumeroDeGols = numeroDeGols;
            Assistencias = assistencias;
            Desarmes = desarmes;
            Altura = altura;
            EhCanhoto = ehCanhoto;
            _doacoes = new List<Doacao>();
        }

        public virtual void DarUmLike()
        {
            Likes++;
        }

        public virtual void Efetuar(Doacao doacao)
        {
            _doacoes.Add(doacao);
        }
    }
}