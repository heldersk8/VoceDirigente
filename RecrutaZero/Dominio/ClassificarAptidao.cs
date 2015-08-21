using System;
using System.Linq;

namespace RecrutaZero.Dominio
{
    public class ClassificarAptidao
    {
        public void Salvar(CandidatoParaSelecao candidatoParaSelecao, Passo passo, string observacao, DateTime data, bool estaApto)
        {
            // TODO: Validar status do processo seletivo
            var aptidaoParaSelecao = candidatoParaSelecao.Aptidoes.FirstOrDefault(x => x.Passo == passo);

            aptidaoParaSelecao.AtribuirObservacao(observacao);
            aptidaoParaSelecao.AtribuirData(data);
            aptidaoParaSelecao.AtribuirStatus(estaApto);
        }
    }
}