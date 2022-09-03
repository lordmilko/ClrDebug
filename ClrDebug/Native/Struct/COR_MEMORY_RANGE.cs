using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("start = {start}, end = {end}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_MEMORY_RANGE
    {
        public ulong start;
        public ulong end;
    }
}
