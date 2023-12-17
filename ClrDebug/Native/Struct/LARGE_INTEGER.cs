using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("QuadPart = {QuadPart}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct LARGE_INTEGER
    {
        public long QuadPart;
    }
}
