using System.Collections.Generic;
using RecrutaZero.Dominio.Comum;
using RecrutaZero.Dominio.Validacao;

namespace RecrutaZero.Dominio
{
    public abstract class Passo : ObjetoDeValor<Passo>
    {
        public virtual int Id { get; protected set; }
        public virtual string Descricao { get; protected set; }

        protected Passo() { }

        internal Passo(int id, string descricao)
        {
            Validacao<Passo>.EhObrigatorio(id, "Id deve ser informado");
            Validacao<Passo>.EhObrigatorio(descricao, "Descrição deve ser informada");

            Id = id;
            Descricao = descricao;
        }

        protected override bool TodosOsAtributosSaoIguais(Passo outroObjetoDeValor)
        {
            return Id == outroObjetoDeValor.Id;
        }

        protected override int ObterHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public enum StatusDoPasso
    {
        NaoAvaliado,
        Apto,
        Inapto
    }

    public class AvaliacaoTecnica : Passo
    {
        public AvaliacaoTecnica() : base(1, "Avaliação Técnica") { }
    }

    public class Mbti : Passo
    {
        public Mbti() : base(2, "MBTI") { }
    }

    public class Dinamica : Passo
    {
        public Dinamica() : base(3, "Dinâmica") { }
    }

    public class Assesment : Passo
    {
        public Assesment() : base(4, "Assesment") { }
    }

    public class EntrevistaRh : Passo
    {
        public EntrevistaRh() : base(5, "Entrevista com RH") { }
    }

    public class EntrevistaTecnica : Passo
    {
        public EntrevistaTecnica() : base(6, "Entrevista técnica") { }
    }

    public class TodosOsPassos
    {
        public static IEnumerable<Passo> ListarTodos
        {
            get
            {
                return new List<Passo>
                {
                    new AvaliacaoTecnica(),
                    new Mbti(),
                    new Dinamica(),
                    new Assesment(),
                    new EntrevistaRh(),
                    new EntrevistaTecnica()
                };
            }
        }
    }
}