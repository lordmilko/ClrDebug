using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("int64 = {int64}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct CY
    {
        public long int64;
    }
}
