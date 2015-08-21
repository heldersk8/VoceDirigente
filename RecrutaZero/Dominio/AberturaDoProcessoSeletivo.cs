using System;
using System.Collections.Generic;
using System.Linq;
using RecrutaZero.Dominio.EnvioDeEmail;

namespace RecrutaZero.Dominio
{
    public class AberturaDoProcessoSeletivo : IAberturaDoProcesso
    {
        private readonly ICandidatoRepositorio _candidatoRepositorio;
        private readonly IEnvioDeEmail _envioDeEmail;
        private readonly IComunicacaoComFacebook _comunicacaoComFacebook;

        public AberturaDoProcessoSeletivo(ICandidatoRepositorio candidatoRepositorio, IEnvioDeEmail envioDeEmail, IComunicacaoComFacebook comunicacaoComFacebook)
        {
            _candidatoRepositorio = candidatoRepositorio;
            _envioDeEmail = envioDeEmail;
            _comunicacaoComFacebook = comunicacaoComFacebook;
        }

        public void Abrir(ProcessoSeletivo processoSeletivo)
        {
            var candidatosAptos = _candidatoRepositorio.ObterTodosOsCandidatosPara(processoSeletivo.Ocupacao);

            var candidatosParaSelecao = CriarCandidatosParaSelecao(processoSeletivo, candidatosAptos);

            processoSeletivo.Abrir(candidatosParaSelecao);

            EnviarEmails(processoSeletivo);

            try
            {
                PostarNoFacebook(processoSeletivo.Ocupacao);
            }
            catch (Exception e) { }
        }

        private void EnviarEmails(ProcessoSeletivo processoSeletivo)
        {
            foreach (var candidatoParaEnviarEmail in processoSeletivo.Candidatos)
                _envioDeEmail.Enviar(candidatoParaEnviarEmail.Nome, candidatoParaEnviarEmail.Email);
        }

        private static IEnumerable<CandidatoParaSelecao> CriarCandidatosParaSelecao(ProcessoSeletivo processoSeletivo, IEnumerable<Candidato> candidatosAptos)
        {
            return candidatosAptos.Select(x => new CandidatoParaSelecao(x, processoSeletivo.Id));
        }

        private void PostarNoFacebook(Ocupacao ocupacao)
        {
            var mensagem = string.Format("Vaga para {0} em {1}", ocupacao.Descricao, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            _comunicacaoComFacebook.Postar(mensagem);
        }
    }
}