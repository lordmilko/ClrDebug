using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("QuadPart = {QuadPart}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct ULARGE_INTEGER
    {
        public long QuadPart;
    }
}
