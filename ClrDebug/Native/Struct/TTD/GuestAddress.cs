using System;

namespace ClrDebug.TTD
{
    public struct GuestAddress : IEquatable<GuestAddress>
    {
        public nint Value;

        public override string ToString() => "0x" + Value.ToString("X");

        public static implicit operator GuestAddress(nint value) => new GuestAddress { Value = value };
        public static implicit operator GuestAddress(int value) => new GuestAddress { Value = (nint) value };
        public static implicit operator GuestAddress(long value) => new GuestAddress { Value = (nint) value };

        public static implicit operator nint(GuestAddress value) => value.Value;
        public static unsafe implicit operator long(GuestAddress value) => (long) (void*) value.Value;

        public override bool Equals(object obj)
        {
            if (obj is nint l)
                return Value == l;

            return obj is GuestAddress other && Equals(other);
        }

        public static bool operator ==(GuestAddress left, GuestAddress right) =>
            left.Value == right.Value;

        public static bool operator !=(GuestAddress left, GuestAddress right) => left.Value != right.Value;

        public bool Equals(GuestAddress other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
