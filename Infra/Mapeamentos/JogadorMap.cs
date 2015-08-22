using Dominio.Jogadores;
using Infra._Base.Mapeamentos;

namespace Infra.Mapeamentos
{
    public class JogadorMap : MapBase<Jogador>
    {
        public JogadorMap()
        {
            Map(jogador => jogador.Altura);
            Map(jogador => jogador.Assistencias);
            Map(jogador => jogador.DataDeNascimento);
            Map(jogador => jogador.Desarmes);
            Map(jogador => jogador.EhCanhoto);
            Map(jogador => jogador.Apelido);
            Map(jogador => jogador.Nome);
            Map(jogador => jogador.NumeroDeGols);
            Map(jogador => jogador.Posicao);
            Map(jogador => jogador.ValorDoPasse);
            Map(jogador => jogador.Likes);
            Map(jogador => jogador.Dislikes);
            HasMany(x => x.Doacoes).Cascade.AllDeleteOrphan();
        }
    }
}
