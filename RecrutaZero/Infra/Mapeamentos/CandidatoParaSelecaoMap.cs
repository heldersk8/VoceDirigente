using RecrutaZero.Dominio;
using RecrutaZero.Infra._Base.Mapeamentos;

namespace RecrutaZero.Infra.Mapeamentos
{
    public class CandidatoParaSelecaoMap : MapBase<CandidatoParaSelecao>
    {
        public CandidatoParaSelecaoMap()
        {
            References(x => x.Ocupacao);
            Map(x => x.Nome);
            Map(x => x.Email);
            Map(x => x.Origem);
            Map(x => x.Telefone);
            Map(x => x.Twitter); 
            Map(x => x.Facebook);
            Map(x => x.Linkedin);
            Map(x => x.SitePessoal);
            References(x => x.Candidato);
            Map(x => x.IdProcessoSeletivo);
            HasMany(x => x.Aptidoes).Cascade.All();
        }
    }
}