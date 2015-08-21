namespace RecrutaZero.Dominio.Testes.Builders
{
    internal class OcupacaoBuilder
    {
        private readonly string _descricao;

        private OcupacaoBuilder()
        {
            _descricao = "Descrição";
        }

        public static OcupacaoBuilder UmaOcupacao()
        {
            return new OcupacaoBuilder();
        }

        public Ocupacao Build()
        {
            return new Ocupacao(_descricao);
        }
    }
}