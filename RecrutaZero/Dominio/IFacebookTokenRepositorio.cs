using RecrutaZero.Dominio.Repositorios;

namespace RecrutaZero.Dominio
{
    public interface IFacebookTokenRepositorio : IRepositorioBase<FacebookToken>
    {
        string ObterToken();
    }
}