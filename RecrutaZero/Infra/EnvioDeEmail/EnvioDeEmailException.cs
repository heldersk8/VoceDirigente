using System;

namespace RecrutaZero.Infra.EnvioDeEmail
{
    public class EnvioDeEmailException : Exception
    {
        public EnvioDeEmailException(string message) : base(message) { }
    }
}
