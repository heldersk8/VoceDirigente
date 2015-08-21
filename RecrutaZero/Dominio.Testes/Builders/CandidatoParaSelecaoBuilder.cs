using RecrutaZero.Dominio.Testes.Helpers.Extensions;

namespace RecrutaZero.Dominio.Testes.Builders
{
    public class CandidatoParaSelecaoBuilder
    {
        private Ocupacao _ocupacao = OcupacaoBuilder.UmaOcupacao().Build();
        private string _time = "Desenvolvimento";
        private string _descricaoDaVaga = "Descrição da vaga";
        private Candidato _candidato = CandidatoBuilder.UmCandidato().Build();
        private int _idProcessoSeletivo = 1;
        private StatusDoCandidatoNoProcesso _status;


        public static CandidatoParaSelecaoBuilder UmCandidatoParaSelecao()
        {
            return new CandidatoParaSelecaoBuilder();
        }

        public CandidatoParaSelecao Build()
        {
            var candidatoParaSelecao = new CandidatoParaSelecao(_candidato, _idProcessoSeletivo);
            candidatoParaSelecao.Setar(() => candidatoParaSelecao.Status, _status);

            return candidatoParaSelecao;
        }

        public CandidatoParaSelecaoBuilder ComStatus(StatusDoCandidatoNoProcesso status)
        {
            _status = status;
            return this;
        }
    }
}
