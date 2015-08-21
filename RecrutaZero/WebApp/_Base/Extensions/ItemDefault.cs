namespace RecrutaZero.WebApp._Base.Extensions
{
    public class ItemDefault
    {
        public string Texto { get; private set; }
        public string Valor { get; private set; }

        private ItemDefault(string texto, string valor)
        {
            Texto = texto;
            Valor = valor;
        }

        public static ItemDefault ComTextoEValoresVazios()
        {
            return new ItemDefault(string.Empty, string.Empty);
        }

        public static ItemDefault ComTextoEValor(string texto, string valor)
        {
            return new ItemDefault(texto, valor);
        }
    }
}