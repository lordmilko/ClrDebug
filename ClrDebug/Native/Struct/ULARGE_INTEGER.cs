using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("QuadPart = {QuadPart}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct ULARGE_INTEGER
    {
        public long QuadPart;

        public static implicit operator ULARGE_INTEGER(long value) => new ULARGE_INTEGER { QuadPart = value };
        public static implicit operator long(ULARGE_INTEGER value) => value.QuadPart;
    }
}
