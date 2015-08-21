using System.Collections.Generic;
using RecrutaZero.Dominio.Repositorios;

namespace RecrutaZero.Dominio
{
    public interface ICandidatoParaSelecaoRepositorio : IRepositorioBase<CandidatoParaSelecao>
    {
        IEnumerable<CandidatoParaSelecao> ObterPor(Candidato candidato);
    }
}