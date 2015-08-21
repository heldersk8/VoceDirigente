using System.ComponentModel;

namespace RecrutaZero.Dominio
{
    public enum StatusDoProcessoSeletivo
    {
        Pendente,
        [Description("Em andamento")]
        EmAndamento,
        Finalizado,
        Suspenso,
        Cancelado
    }
}