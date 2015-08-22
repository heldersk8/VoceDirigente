using System.Collections;
using Dominio.Jogadores;

namespace Dominio.Repositorios
{
    public interface IDadosDaCarreiraRepositorio : IRepositorioBase<DadosDaCarreira>
    {
        DadosDaCarreira BuscaPorIdDoJogador(int IdDoJogador);
    }
}