using System;

namespace RecrutaZero.Dominio
{
    public interface IEncerramentoDeProcessoSeletivo
    {
        void Encerrar(ProcessoSeletivo processoSeletivo, DateTime dataDeEncerramento);
    }
}
