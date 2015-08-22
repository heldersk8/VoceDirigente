using Dominio.Jogadores;
using Infra._Base.Mapeamentos;

namespace Infra.Mapeamentos
{
    public class JogadorMap : MapBase<Jogador>
    {
        public JogadorMap()
        {
            Map(x => x.Altura);
            Map(x => x.Assistencias);
            Map(x => x.DataDeNascimento);
            Map(x => x.Desarmes);
            Map(x => x.EhCanhoto);
            Map(x => x.Apelido);
            Map(x => x.Nome);
            Map(x => x.NumeroDeGols);
            Map(x => x.Posicao);
            Map(x => x.ValorDoPasse);
            Map(x => x.Likes);
            Map(x => x.Dislikes);
        }
    }
}
