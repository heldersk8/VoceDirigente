using Dominio.Comum;

namespace Dominio.Jogadores
{
    public class Titulo : Entidade<Titulo>
    {
        public virtual string NomeDoCampeonato { get; set; }
        public virtual int Ano { get; set; }
        public virtual int QuantidadeDeGols { get; set; }

        protected Titulo() { }

        public Titulo(string nomeDoCampeonato, int ano, int quantidadeDeGols)
        {
            NomeDoCampeonato = nomeDoCampeonato;
            Ano = ano;
            QuantidadeDeGols = quantidadeDeGols;
        }
    }
}