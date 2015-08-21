namespace RecrutaZero.Dominio.Testes.Builders
{
    public class CandidatoBuilder
    {
        private string _nome = "Nome";
        private Ocupacao _ocupacao = new Ocupacao("Desenvolvedor");
        private string _email = "a@a.com";
        private string _origem = "indicação";
        private string _telefone = "99999999";
        private string _twitter;
        private string _facebook;
        private string _linkedIn;
        private string _sitePessoal;

        public Candidato Build()
        {
            var candidato = new Candidato(_nome, _ocupacao, _email, _origem, _telefone);

            candidato.AdicionarInformacoesAdicionais(_twitter, _facebook, _linkedIn, _sitePessoal);

            return candidato;
        }

        public static CandidatoBuilder UmCandidato()
        {
            return new CandidatoBuilder();
        }

        public CandidatoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CandidatoBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public CandidatoBuilder ComOrigem(string origem)
        {
            _origem = origem;
            return this;
        }

        public CandidatoBuilder ComTelefone(string telefone)
        {
            _telefone = telefone;
            return this;
        }

        public CandidatoBuilder ComTwitter(string twitter)
        {
            _twitter = twitter;
            return this;
        }

        public CandidatoBuilder ComFacebook(string facebook)
        {
            _facebook = facebook;
            return this;
        }

        public CandidatoBuilder ComLinkedIn(string linkedIn)
        {
            _linkedIn = linkedIn;
            return this;
        }

        public CandidatoBuilder ComSitePessoal(string sitePessoal)
        {
            _sitePessoal = sitePessoal;
            return this;
        }
    }
}
