using System.Collections.Generic;
using RecrutaZero.Dominio.Repositorios;

namespace RecrutaZero.Dominio
{
    public interface ICandidatoRepositorio : IRepositorioBase<Candidato>
    {
        IEnumerable<Candidato> ObterTodosOsCandidatosPara(Ocupacao ocupacao);
    }
}