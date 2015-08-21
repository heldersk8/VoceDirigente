using Facebook;
using RecrutaZero.Dominio;
using RecrutaZero.Dominio.EnvioDeEmail;
using RecrutaZero.Infra.Dao;

namespace RecrutaZero.Infra.RedesSociais
{
    public class ComunicacaoComFacebook : IComunicacaoComFacebook
    {
        const string ApplicationId = "654541561301025";
        const string ApplicationSecret = "046143af4f70b4790922beca80c10910";
        const string AccessToken = "CAACEdEose0cBAJYJ9kQXkiBZAAuNCGbAJHr65CpMTRZArO4olMWjZBmaoKiKMR4wrqmv5jMiBqvg6L9aGAYZBWUFm6WwRhHsiFFtmHjsOaNuvySZCnd96f5mKwGx8ZA4aZC8xQQRRSOrx9qvSb9TZCNpBa6QZAr3XRIjMJ6chZBO9dARRn3L3yZCD1GlTZCHCytyOJTViMCTt0IzuwZDZD";

        private readonly IFacebookTokenRepositorio _facebookTokenRepositorio;

        public ComunicacaoComFacebook(IFacebookTokenRepositorio facebookTokenRepositorio)
        {
            _facebookTokenRepositorio = facebookTokenRepositorio;
        }

        public void Postar(string mensagem)
        {
            var token = _facebookTokenRepositorio.ObterToken();
            var client = new FacebookClient { AccessToken = token };

            client.Post("me/feed", new { message = mensagem });
        }
    }
}