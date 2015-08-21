namespace RecrutaZero.Dominio.EnvioDeEmail
{
    public interface IEnvioDeEmail
    {
        void Enviar(string nome, string emailDeDestinatario);
        void EnviarEmailDuMau(string nome, string emailDeDestinatario);
    }
}