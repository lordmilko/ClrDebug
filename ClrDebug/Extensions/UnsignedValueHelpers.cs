using System;

namespace ClrDebug
{
    internal static class UnsignedValueHelpers
    {
        public static int CompareTo(ulong first, object second)
        {
            if (second is int i)
                return first.CompareTo((ulong) i);

            if (second is uint u)
                return first.CompareTo((ulong) u);

            if (second is long l)
                return first.CompareTo((ulong)l);

            if (second is ulong ul)
                return first.CompareTo(ul);

            return first.CompareTo(second);
        }

        public static int CompareTo(uint first, object second)
        {
            if (second is int i)
                return first.CompareTo((uint) i);

            if (second is uint u)
                return first.CompareTo(u);

            return first.CompareTo(second);
        }

        public static bool Equals<T>(T first, object second) where T : IEquatable<T>
        {
            if (ReferenceEquals(null, second))
                return false;

            if (ReferenceEquals(first, second))
                return true;

            if (second is int || second is uint || second is T)
                return first.Equals((T)second);

            return false;
        }
    }
}
