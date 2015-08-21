using Dominio.Comum;
using System;

namespace Dominio.Jogadores
{
    public class Jogador : Entidade<Jogador>
    {
        public virtual string Nome { get; set; }
        public virtual DateTime DataDeNascimento { get; set; }
        public virtual Posicao Posicao { get; set; }
        public virtual int NumeroDeGols { get; set; }
        public virtual int Assistencias { get; set; }
        public virtual int Desarmes { get; set; }
        public virtual int Altura { get; set; }
        public virtual bool EhCanhoto { get; set; }
        public virtual decimal ValorDoPasse { get; set; }

        protected Jogador() { }

        public Jogador(string nome, DateTime dataDeNascimento, Posicao posicao, int numeroDeGols, int assistencias, int desarmes, int altura, bool ehCanhoto)
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Posicao = posicao;
            NumeroDeGols = numeroDeGols;
            Assistencias = assistencias;
            Desarmes = desarmes;
            Altura = altura;
            EhCanhoto = ehCanhoto;
        }
    }
}