using System.Collections.Generic;
using RecrutaZero.Dominio;
using RecrutaZero.Dominio.Specifications;

namespace RecrutaZero.WebApp.ViewModels
{
    public class ConsultaDeProcessoSeletivoVm
    {
        public int OcupacaoId { get; set; }
        public IEnumerable<OcupacaoVm> Ocupacoes { get; set; }
    }

    public class ConsultaDeCandidatoVm
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int OcupacaoId { get; set; }
        public IEnumerable<OcupacaoVm> Ocupacoes { get; set; }

        public ISpecification<Candidato> Specification()
        {
            return SpecificationBuilder<Candidato>.UmaSpec()
                .Quando(!string.IsNullOrWhiteSpace(Nome), x => x.Nome.Contains(Nome))
                .Quando(!string.IsNullOrWhiteSpace(Telefone), x => x.Telefone.Contains(Telefone))
                .Quando(OcupacaoId > 0, x => x.Ocupacao.Id == OcupacaoId)
                .Build();
        }
    }
}