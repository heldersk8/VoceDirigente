using System;

namespace ODirigente.Infra
{
    public static class EventosWeb
    {
        public static event EventHandler ChamadaRecebida;
        public static event EventHandler ChamadaEncerrada;

        public static void EncerrandoChamada()
        {
            var handler = ChamadaEncerrada;
            if (handler != null) handler(null, EventArgs.Empty);
        }

        public static void RecebendoChamada()
        {
            var handler = ChamadaRecebida;
            if (handler != null) handler(null, EventArgs.Empty);
        }
    }
}