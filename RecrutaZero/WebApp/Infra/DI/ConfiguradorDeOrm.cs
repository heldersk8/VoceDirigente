using RecrutaZero.Infra.SessionFactory;
using RecrutaZero.Infra._Base.Configuracoes;
using RecrutaZero.WebApp.EventHandlers;

namespace RecrutaZero.WebApp.Infra.DI
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
            Configurador.Configurar(new ConfiguradorDeSessionFactory(), ServidorDePublicacao.Producao);
        }
    }
}