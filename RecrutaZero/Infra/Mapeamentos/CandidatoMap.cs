using RecrutaZero.Dominio;
using RecrutaZero.Infra._Base.Mapeamentos;

namespace RecrutaZero.Infra.Mapeamentos
{
    public class CandidatoMap : MapBase<Candidato>
    {
        public CandidatoMap()
        {
            Map(x => x.Nome);
            References(x => x.Ocupacao);
            Map(x => x.Email);
            Map(x => x.Origem);
            Map(x => x.Telefone);
            Map(x => x.Twitter);
            Map(x => x.Facebook);
            Map(x => x.Linkedin);
            Map(x => x.SitePessoal);
            Map(x => x.Status);
            Map(x => x.DataDeContratacao);
        }
    }
}