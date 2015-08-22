using Infra.SessionFactory;
using Infra._Base.Configuracoes;

namespace ODirigente.Infra
{
    public static class ConfiguradorDeOrm
    {
        public static void Configurar()
        {
            VerificarOrmConfigurado();

            EventosWeb.ChamadaRecebida += (s, args) =>
            {
                VerificarOrmConfigurado();
                Contexto.LigarContextoDaSessaoNh();
            };

            EventosWeb.ChamadaEncerrada += (s, args) => Contexto.DesligarContextoDaSessaoNh();
        }

        private static void VerificarOrmConfigurado()
        {
            if (Contexto.SessionFactory != null)
                return;

            const ServidorDePublicacao servidorDePublicacao = ServidorDePublicacao.Desenvolvimento;

            Configurador.Configurar(new ConfiguradorDeSessionFactory(), servidorDePublicacao);
        }

    }
}