using System;

namespace RecrutaZero.Dominio.Comum
{
    public abstract class ObjetoDeValor<T> : IEquatable<T> where T : ObjetoDeValor<T>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public override int GetHashCode()
        {
            return ObterHashCode();
        }

        public virtual bool Equals(T outroObjetoDeValor)
        {
            if (ReferenceEquals(null, outroObjetoDeValor)) return false;
            if (ReferenceEquals(this, outroObjetoDeValor)) return true;
            return TodosOsAtributosSaoIguais(outroObjetoDeValor);
        }

        public static bool operator ==(ObjetoDeValor<T> left, ObjetoDeValor<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObjetoDeValor<T> left, ObjetoDeValor<T> right)
        {
            return !Equals(left, right);
        }

        protected abstract bool TodosOsAtributosSaoIguais(T outroObjetoDeValor);
        protected abstract int ObterHashCode();
    }
}