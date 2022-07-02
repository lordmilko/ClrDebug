using System;

namespace ClrDebug
{
    internal static class UnsignedValueHelpers
    {
        public static int CompareTo<T>(ulong first, object second)
        {
            if (second is T || second is int || second is ulong)
                return first.CompareTo((uint)second);

            return first.CompareTo(second);
        }

        public static int CompareTo<T>(uint first, object second)
        {
            if (second is T || second is int || second is uint)
                return first.CompareTo((uint)second);

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
