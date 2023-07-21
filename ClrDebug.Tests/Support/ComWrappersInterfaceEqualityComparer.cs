using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ClrDebug.Tests
{
#if GENERATED_MARSHALLING
    public class ComWrappersInterfaceEqualityComparer<T> : IEqualityComparer<T>
    {
        public static readonly ComWrappersInterfaceEqualityComparer<T> Instance = new ComWrappersInterfaceEqualityComparer<T>();

        public bool Equals(T x, T y)
        {
            if (ComWrappers.TryGetComInstance(x, out var p1) && ComWrappers.TryGetComInstance(y, out var p2))
                return p1.Equals(p2);

            return false;
        }

        public int GetHashCode(T obj)
        {
            if (ComWrappers.TryGetComInstance(obj, out var ptr))
                return ptr.GetHashCode();

            return obj.GetHashCode();
        }
    }
#endif
}
