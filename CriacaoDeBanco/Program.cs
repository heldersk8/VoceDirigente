using System;

namespace CriacaoDeBanco
{
    class Program
    {
        static void Main()
        {
            try
            {
                AtualizacaoDeBanco.Executar();
            }
            catch (Exception ex)
            {
                EscreverMensagemDeErro(ex);
            }

            Console.WriteLine("\nPressione qualquer tecla para encerrar.");
            Console.ReadKey();
        }

        private static void EscreverMensagemDeErro(Exception ex)
        {
            Console.WriteLine(new string('#', 50));
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(new string('#', 50));
            if (ex.InnerException != null)
                EscreverMensagemDeErro(ex.InnerException);
        }
    }
}