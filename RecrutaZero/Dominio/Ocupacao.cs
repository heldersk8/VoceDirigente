using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RecrutaZero.Dominio.Comum;
using RecrutaZero.Dominio.Validacao;

namespace RecrutaZero.Dominio
{
    public class Ocupacao : Entidade<Ocupacao>
    {
        public virtual string Descricao { get; protected set; }

        protected Ocupacao() { }

        public Ocupacao(string descricao)
        {
            Validacao<Ocupacao>.EhObrigatorio(descricao, "Descrição é obrigatória");

            Descricao = descricao;
        }
    }
}