namespace RecrutaZero.Dominio.Testes.Builders
{
    internal class ProcessoSeletivoBuilder
    {
        private Ocupacao _ocupacao = OcupacaoBuilder.UmaOcupacao().Build();
        private string _time = "Desenvolvimento";
        private string _descricaoDaVaga = "Descrição da vaga";

        public static ProcessoSeletivoBuilder UmProcessoSeletivo()
        {
            return new ProcessoSeletivoBuilder();
        }

        public ProcessoSeletivo Build()
        {
            return new ProcessoSeletivo(_ocupacao,_time,_descricaoDaVaga);
        }
    }
}
