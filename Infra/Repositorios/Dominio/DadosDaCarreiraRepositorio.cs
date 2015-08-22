using System.Collections.Generic;
using System.Linq;
using Dominio.Jogadores;
using Dominio.Repositorios;
using Infra._Base.Repositorios;
using NHibernate;

namespace Infra.Repositorios.Dominio
{
    public class DadosDaCarreiraRepositorio : RepositorioBaseDominio<DadosDaCarreira>, IDadosDaCarreiraRepositorio
    {
        public DadosDaCarreiraRepositorio(ISession sessao) : base(sessao)
        {
        }

        public DadosDaCarreira BuscaPorIdDoJogador(int IdDoJogador)
        {
            return Entidades().FirstOrDefault(x => x.Jogador.Id == IdDoJogador);
        }
    }
}