using FluentNHibernate.Mapping;
using RecrutaZero.Dominio;
using RecrutaZero.Infra._Base.Mapeamentos;

namespace RecrutaZero.Infra.Mapeamentos
{
    public sealed class PassoMap : ClassMap<Passo>
    {
        public PassoMap()
        {
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Descricao);
            DiscriminateSubClassesOnColumn("Tipo");
        }
    }
    
    public class AvaliacaoTecnicaMap : SubclassMap<AvaliacaoTecnica> { }
    public class MbtiMap : SubclassMap<Mbti> { }
    public class DinamicaMap : SubclassMap<Dinamica> { }
    public class AssesmentMap : SubclassMap<Assesment> { }
    public class EntrevistaRhMap : SubclassMap<EntrevistaRh> { }
    public class EntrevistaTecnicaMap : SubclassMap<EntrevistaTecnica> { }
}
