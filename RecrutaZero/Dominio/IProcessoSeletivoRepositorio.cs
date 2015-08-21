using System.Collections.Generic;
using RecrutaZero.Dominio.Repositorios;

namespace RecrutaZero.Dominio
{
    public interface IProcessoSeletivoRepositorio : IRepositorioBase<ProcessoSeletivo> {
        IEnumerable<ProcessoSeletivo> ObterPorOcupacao(int ocupacaoId);
    }
}