using System;

namespace ClrDebug.TTD
{
    public readonly struct UniqueThreadId : IEquatable<UniqueThreadId>
    {
        public readonly int Value;

        public UniqueThreadId(int value)
        {
            Value = value;
        }

        public static implicit operator UniqueThreadId(int value) => new UniqueThreadId(value);
        public static implicit operator int(UniqueThreadId value) => value.Value;

        public bool Equals(UniqueThreadId other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is UniqueThreadId other)
                return Equals(other);

            if (obj is int i)
                return Value == i;

            return false;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public override string ToString() => Value.ToString();
    }
}
