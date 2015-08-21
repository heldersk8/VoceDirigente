namespace RecrutaZero.Dominio
{
    public class ServicoParaContratarCandidato : IServicoParaContratarCandidato
    {
        private readonly ICandidatoParaSelecaoRepositorio _candidatoParaSelecaoRepositorio;

        public ServicoParaContratarCandidato(ICandidatoParaSelecaoRepositorio candidatoParaSelecaoRepositorio)
        {
            _candidatoParaSelecaoRepositorio = candidatoParaSelecaoRepositorio;
        }

        public void MarcarCandidatoComoContratado(Candidato candidato)
        {
            var candidatos = _candidatoParaSelecaoRepositorio.ObterPor(candidato);

            foreach (var candidatoParaSelecao in candidatos)
            {
                candidatoParaSelecao.MarcarComoContratadoParaOProcessoDeSelecao();
            }
        }
    }
}