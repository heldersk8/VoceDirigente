using Dominio.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Doacoes;

namespace Dominio.Jogadores
{
    public class Jogador : Entidade<Jogador>
    {
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
        public virtual IEnumerable<Doacao> Doacoes { get; set; }
        public virtual decimal TotalDeDoacoes { get { return Doacoes.Sum(x => x.Valor); } }
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
            Doacoes = new List<Doacao>();
        }

        public virtual void DarUmLike()
        {
            Likes++;
        }
    }
}