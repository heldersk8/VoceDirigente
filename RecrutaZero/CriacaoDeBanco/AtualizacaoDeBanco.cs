using System;
using System.Configuration;
using System.Diagnostics;
using NHibernate.Context;
using RecrutaZero.Infra.SessionFactory;
using RecrutaZero.Infra._Base.Configuracoes;

namespace RecrutaZero.CriacaoDeBanco
{
    public class AtualizacaoDeBanco
    {
        public static void Executar()
        {
            const ServidorDePublicacao servidorDePublicacao = ServidorDePublicacao.Desenvolvimento;
            var configuradorDeSessionFactory = EscolherConfiguradorDeSessionFactory();

            Configurador.Configurar(configuradorDeSessionFactory, servidorDePublicacao, true, true);
            Console.WriteLine("\nBanco atualizado com sucesso!!!!");

            if (configuradorDeSessionFactory is ConfiguradorDeSessionFactory)
                ExecutarScriptDeInclusaoDeDados(servidorDePublicacao);
        }

        private static ConfiguradorDeSessionFactory<WebSessionContext> EscolherConfiguradorDeSessionFactory()
        {
            string tipoDeAtualizacao, confirmacao;
            do
            {
                Console.WriteLine("Forma de atualização:");
                Console.WriteLine("[R] para recriar o banco ### ATENÇÃO: Todos os dados serão destruidos ####");
                Console.WriteLine("[A] para atualizar esquema existente");

                tipoDeAtualizacao = Console.ReadLine().ToUpper();
                Console.Write("Confirmar <S/N>: ");
                confirmacao = Console.ReadLine().ToUpper();

            } while (confirmacao != "S" || (tipoDeAtualizacao != "R" && tipoDeAtualizacao != "A"));

            if (tipoDeAtualizacao == "R")
                return new ConfiguradorDeSessionFactory();

            return new ConfiguradorDeSessionFactoryComAtualizacaoDeEsquema();
        }

        private static void ExecutarScriptDeInclusaoDeDados(ServidorDePublicacao servidorDePublicacao)
        {
            string confirmacao;
            do
            {
                Console.Write("\nDeseja executar script de inclusão de dados? <S/N>: ");
                confirmacao = Console.ReadLine().ToUpper();
                if (confirmacao == "N") return;

            } while (confirmacao != "S");

            var arquivo = ConfigurationManager.AppSettings["ScriptDeDados-" + servidorDePublicacao];
            Console.WriteLine("Script: " + arquivo);
            ExecutarScript(arquivo);
        }

        private static void ExecutarScript(string arquivo)
        {
            var processStartInfo = new ProcessStartInfo
                                       {
                                           Arguments = String.Format("-executionPolicy unrestricted -File {0}", arquivo),
                                           FileName = "powershell.exe",
                                           WindowStyle = ProcessWindowStyle.Normal
                                       };
            Process.Start(processStartInfo).WaitForExit();
        }
    }
}