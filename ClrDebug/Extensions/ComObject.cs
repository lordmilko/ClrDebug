using System;
using System.Collections.Generic;

namespace ClrDebug
{
    public class ComObject<T> : IEquatable<ComObject<T>>
    {
        public T Raw { get; }

        protected ComObject(T raw)
        {
            if (raw == null)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (!(obj is ComObject<T>))
                return false;

            return Equals((ComObject<T>)obj);
        }

        public bool Equals(ComObject<T> other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return Raw.Equals(other.Raw);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Raw);
        }
    }
}
