using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("QuadPart = {QuadPart}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct LARGE_INTEGER
    {
        public long QuadPart;

        public static implicit operator LARGE_INTEGER(long value) => new LARGE_INTEGER {QuadPart = value};
        public static implicit operator long(LARGE_INTEGER value) => value.QuadPart;
    }
}
