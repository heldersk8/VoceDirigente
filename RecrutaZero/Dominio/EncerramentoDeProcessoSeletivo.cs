using System;
using System.Collections.Generic;
using System.Linq;
using RecrutaZero.Dominio.EnvioDeEmail;

namespace RecrutaZero.Dominio
{
    public class EncerramentoDeProcessoSeletivo : IEncerramentoDeProcessoSeletivo
    {
        private readonly IEnvioDeEmail _envioDeEmail;

        public EncerramentoDeProcessoSeletivo(IEnvioDeEmail envioDeEmail)
        {
            _envioDeEmail = envioDeEmail;
        }

        public void Encerrar(ProcessoSeletivo processoSeletivo, DateTime dataDeEncerramento)
        {
            processoSeletivo.Encerrar(dataDeEncerramento);

            var candidatosNaoContratados = processoSeletivo.Candidatos.Where(x => x.Status != StatusDoCandidatoNoProcesso.Contratado);

            foreach (var candidatoReprovado in candidatosNaoContratados)
                _envioDeEmail.EnviarEmailDuMau(candidatoReprovado.Nome, candidatoReprovado.Email);
        }
    }
}
